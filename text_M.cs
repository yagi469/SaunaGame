using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_M : MonoBehaviour
{
    //1�ڂ�Text
    public RectTransform text1;
    //�Q�ڂ�Text
    public RectTransform text2;

    public RectTransform canvas;




    // Start is called before the first frame update
    void Start()
    {
        //�Q�[����ʂ̉����Əc���̃s�N�Z��
        //Debug.Log("Screen Width : " + Screen.width);
        //Debug.Log("Screen  height: " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {

        //���b ��f����������
       text1.position += new Vector3(-0.2f, 0f, 0f);
        text2.position += new Vector3(-0.2f, 0f, 0f);
       //Debug.Log("text1.x" + text1.position.x);
       // Debug.Log("text2.x" + text2.position.x);



        //�����Atext1��position.x��0�̎�
        if (text1.position.x < -278f)
        {

            text1.position = new Vector3(1200f, text2.position.y, text2.position.z);
        }

        if (text2.position.x < -278f)
        {
            text2.position = new Vector3(1200f, text2.position.y, text2.position.z);
        }

    }
}
