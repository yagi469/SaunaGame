using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    //�^�C�}�[�p�ϐ�
    public float LimitTime;                   //�^�C�}�[�̐ݒ莞��
    private bool counting;�@�@�@�@�@�@�@�@�@�@//�^�C�}�[�ғ��t���O

    //�v���O���X�o�[�p�ϐ�
    //public GameObject CircleProgress;         //�~�^�C�v�̃v���O���X�o�[
    //private Image circle;                     //CircleProgress��Image�擾�p
    //private float PaintSpeed;                 //�h��Ԃ����x�p�ϐ�

    //�v���O���X�o�[�p�ϐ�
    public Slider slider;                     //Slider�I�u�W�F�N�g
    private float PaintSpeed;                 //�h��Ԃ����x�p�ϐ�


    //��������true,
    public bool resultFg = false;

    void Start()
   


    // Start is called before the first frame update
    {
        //CircleProgress��Image�R���|�[�l���g�擾
        //circle = CircleProgress.GetComponent<Image>();
        //�h��Ԃ����x�̐ݒ�
        PaintSpeed = LimitTime;
    }

    // Update is called once per frame
    void Update()
    {
  //     if (counting)
        {
            TimerCount();
        }

    }

    //�^�C�}�[�@�\
    void TimerCount()
    {
        //�ғ����̌o�ߎ���
        LimitTime -= Time.deltaTime;

        ProgressMove();

        //�^�C�}�[�̒�~
        if (LimitTime <= 0)
        {
            counting = false;
        }

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (LimitTime <= -5)
        {
            SceneManager.LoadScene("Scene2");
        }

        //�����A�{�^���������ꂽ������LimitTime��40�`55�̎�
        if (Input.GetMouseButtonDown(0) && LimitTime <= 40 && LimitTime >= 55)
        {
            resultFg = true;
        }
        else
        {
            resultFg = false;
        }

    }
    //�v���O���X�o�[����
    void ProgressMove()
    {
        //�o�ߎ��Ԃ���ړ��ʂ̌v�Z
        float amount = Time.deltaTime / PaintSpeed;

        //�X���C�_�[�̈ړ��ʂ���
        slider.value -= amount;
    }

    //�v���O���X�o�[����
    //void ProgressMove()
    //{
    //    //�o�ߎ��Ԃ���h��Ԃ��ʂ��v�Z
    //    float amount = Time.deltaTime / PaintSpeed;

    //    //�h�Ԃ��ʂ�������
    //    circle.fillAmount += amount;
    //}

    //�^�C�}�[�X�^�[�g
    public void PushStart()
    {
        counting = true;
    }

    
}

/* http://kerotan-factory.xblog.jp/article/473783356.html */
