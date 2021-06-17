using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager_Scene3 : MonoBehaviour
{
    //�^�C�}�[�p�ϐ�
    public float LimitTime;                   //�^�C�}�[�̐ݒ莞��
    private bool counting;�@�@�@�@�@�@�@�@�@�@//�^�C�}�[�ғ��t���O

    //�v���O���X�o�[�p�ϐ�
    public Slider slider;                     //Slider�I�u�W�F�N�g
    private float PaintSpeed;                 //�h��Ԃ����x�p�ϐ�


    void Start()

    // Start is called before the first frame update
    {
        //�h��Ԃ����x�̐ݒ�
        PaintSpeed = LimitTime;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (LimitTime <= -2)
        {
            SceneManager.LoadScene("Scene_result");
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

    //�^�C�}�[�X�^�[�g
    public void PushStart()
    {
        counting = true;
    }
}

/* http://kerotan-factory.xblog.jp/article/473783356.html */
