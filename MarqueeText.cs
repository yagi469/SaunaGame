using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Extensions/MarqueeText")]
    public class MarqueeText : Text
    {
        public enum MarqueeDirection
        {
            Up,
            Down,
            Right,
            Left,
        }

        [SerializeField]
        private FontData m_FontDataCustom = FontData.defaultFontData;

        [SerializeField]
        private MarqueeDirection m_MarqueeDirection = MarqueeDirection.Left;

        [SerializeField]
        [Range(0, 10)]
        private float m_Movevelocity = 5f;

        private IList<UIVertex> mVerts;

        private VertexHelper mVertexHelper = new VertexHelper();

        /// <summary>上下左右的邊界值</summary>
        private float mUpLimeitValue, mDownLimitValue, mLeftLimitValue, mRightLimitValue = 0f;

        /// <summary>邊界容許值</summary>
        private float mMoveOffsetValue = 10f;

        /// <summary>文字物件的寬、高</summary>
        private float mTextZoneWidth = 0f;
        private float mTextZoneHeight = 0f;

        private Vector3 mMoveVector3Value = Vector3.zero;

        private float mIncrementValue = 0f;

        private bool mTextConentChange = false;

        // Use this for initialization

        protected override void Awake()
        {
            switch (m_MarqueeDirection)
            {
                case MarqueeDirection.Up:
                case MarqueeDirection.Down:
                    mDownLimitValue = this.rectTransform.rect.min.y - mMoveOffsetValue;
                    mUpLimeitValue = this.rectTransform.rect.max.y + mMoveOffsetValue;
                    mTextZoneHeight = Mathf.Abs(mUpLimeitValue - mDownLimitValue);
                    break;
                case MarqueeDirection.Right:
                case MarqueeDirection.Left:
                    mLeftLimitValue = this.rectTransform.rect.min.x - mMoveOffsetValue;
                    mRightLimitValue = this.rectTransform.rect.max.x + mMoveOffsetValue;
                    mTextZoneWidth = Mathf.Abs(mLeftLimitValue - mRightLimitValue);
                    break;
            }

            mTextConentChange = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (text == string.Empty)
                return;

            switch (m_MarqueeDirection)
            {
                case MarqueeDirection.Up:
                    mMoveVector3Value = Vector3.up * m_Movevelocity * Time.deltaTime;
                    break;
                case MarqueeDirection.Down:
                    mMoveVector3Value = Vector3.down * m_Movevelocity * Time.deltaTime;
                    break;
                case MarqueeDirection.Right:
                    mMoveVector3Value = Vector3.right * m_Movevelocity * Time.deltaTime;
                    break;
                case MarqueeDirection.Left:
                    mMoveVector3Value = Vector3.left * m_Movevelocity * Time.deltaTime;
                    break;
            }

            if (m_MarqueeDirection == MarqueeDirection.Up || m_MarqueeDirection == MarqueeDirection.Down)
                mIncrementValue += mMoveVector3Value.normalized.y * m_Movevelocity;
            else
                mIncrementValue += mMoveVector3Value.normalized.x * m_Movevelocity;

            //Debug.Log(mIncrementValue + " / " + mIncrementValue % mMovevelocity + "/" + mMoveVector3Value.x);

            if (mIncrementValue % m_Movevelocity == 0f)
                SetVerticesDirty();
        }

        protected override void OnRectTransformDimensionsChange()
        {
            if (gameObject.activeInHierarchy)
            {
                switch (m_MarqueeDirection)
                {
                    case MarqueeDirection.Up:
                    case MarqueeDirection.Down:
                        mDownLimitValue = this.rectTransform.rect.min.y - mMoveOffsetValue;
                        mUpLimeitValue = this.rectTransform.rect.max.y + mMoveOffsetValue;
                        mTextZoneHeight = Mathf.Abs(mUpLimeitValue - mDownLimitValue);
                        break;
                    case MarqueeDirection.Right:
                    case MarqueeDirection.Left:
                        mLeftLimitValue = this.rectTransform.rect.min.x - mMoveOffsetValue;
                        mRightLimitValue = this.rectTransform.rect.max.x + mMoveOffsetValue;
                        mTextZoneWidth = Mathf.Abs(mLeftLimitValue - mRightLimitValue);
                        break;
                }

                // prevent double dirtying...
                if (CanvasUpdateRegistry.IsRebuildingLayout())
                    SetVerticesDirty();
                else
                {
                    SetVerticesDirty();
                    SetLayoutDirty();
                }
            }
        }

        public override string text
        {
            get
            {
                return m_Text;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (String.IsNullOrEmpty(m_Text))
                        return;
                    m_Text = "";
                    SetVerticesDirty();
                }
                else if (m_Text != value)
                {
                    mTextConentChange = true;
                    m_Text = value;
                    SetVerticesDirty();
                    SetLayoutDirty();
                }
            }
        }

        readonly UIVertex[] m_TempVerts = new UIVertex[4];
        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            if (font == null)
                return;

            mVertexHelper = toFill;
            // We don't care if we the font Texture changes while we are doing our Update.
            // The end result of cachedTextGenerator will be valid for this instance.
            // Otherwise we can get issues like Case 619238.

            if (mTextConentChange)
            {
                m_DisableFontTextureRebuiltCallback = true;

                Vector2 extents = rectTransform.rect.size;

                var settings = GetGenerationSettings(extents);

                cachedTextGenerator.Populate(text, settings);
            }

            Rect inputRect = rectTransform.rect;

            // get the text alignment anchor point for the text in local space
            Vector2 textAnchorPivot = GetTextAnchorPivot(m_FontDataCustom.alignment);
            Vector2 refPoint = Vector2.zero;
            refPoint.x = (textAnchorPivot.x == 1 ? inputRect.xMax : inputRect.xMin);
            refPoint.y = (textAnchorPivot.y == 0 ? inputRect.yMin : inputRect.yMax);

            // Determine fraction of pixel to offset text mesh.
            Vector2 roundingOffset = PixelAdjustPoint(refPoint) - refPoint;

            float unitsPerPixel = 1 / pixelsPerUnit;

            mVerts = cachedTextGenerator.verts;

            //Last 4 verts are always a new line...
            int vertCount = mVerts.Count - 4;

            mVertexHelper.Clear();
            if (roundingOffset != Vector2.zero)
            {
                for (int i = 0; i < vertCount; ++i)
                {
                    UIVertex uv = mVerts[i];
                    uv.position += mMoveVector3Value;
                    mVerts[i] = uv;

                    int tempVertsIndex = i & 3;
                    m_TempVerts[tempVertsIndex] = mVerts[i];
                    m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                    m_TempVerts[tempVertsIndex].position.x += roundingOffset.x;
                    m_TempVerts[tempVertsIndex].position.y += roundingOffset.y;

                    if (tempVertsIndex == 3)
                    {
                        if (CheckVertexOutLimit(m_TempVerts))
                        {
                            for (int index = 0; index < 4; index++)
                            {
                                m_TempVerts[index].position += GetVertexNextPos();
                                mVerts[i - 3 + (index)] = m_TempVerts[index];
                            }
                        }

                        mVertexHelper.AddUIVertexQuad(m_TempVerts);
                    }
                }
            }
            else
            {
                for (int i = 0; i < vertCount; ++i)
                {
                    UIVertex uv = mVerts[i];
                    uv.position += mMoveVector3Value;
                    mVerts[i] = uv;

                    int tempVertsIndex = i & 3;
                    m_TempVerts[tempVertsIndex] = mVerts[i];
                    m_TempVerts[tempVertsIndex].position *= unitsPerPixel;

                    if (tempVertsIndex == 3)
                    {
                        if (CheckVertexOutLimit(m_TempVerts))
                        {
                            for (int index = 0; index < 4; index++)
                            {
                                m_TempVerts[index].position += GetVertexNextPos();
                                mVerts[i - 3 + (index)] = m_TempVerts[index];
                            }
                        }

                        mVertexHelper.AddUIVertexQuad(m_TempVerts);
                    }
                }
            }

            m_DisableFontTextureRebuiltCallback = false;
            mTextConentChange = false;
        }

        private bool CheckVertexOutLimit(UIVertex[] checkVector3Arr)
        {
            if (m_MarqueeDirection == MarqueeDirection.Up)
                if (checkVector3Arr[3].position.y > mUpLimeitValue) return true;

            if (m_MarqueeDirection == MarqueeDirection.Down)
                if (checkVector3Arr[0].position.y < mDownLimitValue) return true;

            if (m_MarqueeDirection == MarqueeDirection.Right)
                if (checkVector3Arr[3].position.x > mRightLimitValue) return true;

            if (m_MarqueeDirection == MarqueeDirection.Left)
                if (checkVector3Arr[1].position.x < mLeftLimitValue) return true;

            return false;
        }

        private Vector3 GetVertexNextPos()
        {
            if (m_MarqueeDirection == MarqueeDirection.Up)
                return new Vector3(0f, -mTextZoneHeight, 0f);

            if (m_MarqueeDirection == MarqueeDirection.Down)
                return new Vector3(0f, mTextZoneHeight, 0f);

            if (m_MarqueeDirection == MarqueeDirection.Right)
                return new Vector3(-mTextZoneWidth, 0f, 0f);

            if (m_MarqueeDirection == MarqueeDirection.Left)
                return new Vector3(mTextZoneWidth, 0f, 0f);

            return Vector3.zero;
        }
    }
}
