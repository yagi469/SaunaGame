using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataScript : MonoBehaviour
{

    bool stage1_score = false;
    bool stage2_score = false;
    bool stage3_score = false;

    [Header("�T�E�i��BER�̏��")]
    public GameObject object1; //Inspector�ő��̃I�u�W�F�N�g���w�肵�Ă�������
    //[Header("�����C��BER�̏��")]
     GameObject object2; //Inspector�ő��̃I�u�W�F�N�g���w�肵�Ă�������
    //[Header("�O�C����BER�̏��")]
     GameObject object3; //Inspector�Ńv���C���[�̃I�u�W�F�N�g���w�肵�Ă�������



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        //LimitTime�̐��l���擾

        object1 = GameObject.Find("SAUNA_VER");

        object2 = GameObject.Find("SAUNA_VER2");

        object2 = GameObject.Find("SAUNA_VER3");
        //stage1_score = object1.GetComponent<TimerManager>().LimitTime;

        //stage2_score = object2.GetComponent<TimerManager_Scene2>().LimitTime;

        //stage3_score = object3.GetComponent<TimerManager_Scene3>().LimitTime;



    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //�X�e�[�W�P�i�T�E�i�j�̃{�^���������ꂽ��,���l���擾
    public void score1(bool _stage1_score)
    {

        stage1_score = _stage1_score;

    }

    //�X�e�[�W�Q�i�����C�j�̃{�^���������ꂽ��, ���l���擾
    public void score2(bool _stage2_score)
    {
        stage2_score = _stage2_score;


    }

    //�X�e�[�W�R�i�O�C���j�̃{�^���������ꂽ��,���l���擾
    public void score3(bool _stage3_score)
    {


        stage3_score = _stage3_score;
    }


    //set������set�֐�
    public void set1(bool _stage1_score)
    {
        stage1_score = _stage1_score;
    }

    public void set2(bool _stage2_score)
    {
       stage2_score = _stage2_score;
    }

    public void set3(bool _stage3_score)
    {
        stage3_score = _stage3_score ;
    }

    //�߂�l��get������get�֐�
     public bool get1()
    {
        return stage1_score;
    }

    bool get2()
    {
        return stage2_score;
    }

    bool get3()
    {
        return stage3_score;
    }
}


/*
 �Z�b�g�ƃQ�b�g�̊֐�

    �Z�b�g�B�B�B
     
     */