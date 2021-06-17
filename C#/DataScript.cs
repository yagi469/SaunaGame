using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataScript : MonoBehaviour
{

    bool stage1_score = false;
    bool stage2_score = false;
    bool stage3_score = false;

    [Header("サウナのBERの情報")]
    public GameObject object1; //Inspectorで他のオブジェクトを指定してください
    //[Header("水風呂のBERの情報")]
     GameObject object2; //Inspectorで他のオブジェクトを指定してください
    //[Header("外気浴のBERの情報")]
     GameObject object3; //Inspectorでプレイヤーのオブジェクトを指定してください



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        //LimitTimeの数値を取得

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

    //ステージ１（サウナ）のボタンを押された時,数値を取得
    public void score1(bool _stage1_score)
    {

        stage1_score = _stage1_score;

    }

    //ステージ２（水風呂）のボタンを押された時, 数値を取得
    public void score2(bool _stage2_score)
    {
        stage2_score = _stage2_score;


    }

    //ステージ３（外気浴）のボタンを押された時,数値を取得
    public void score3(bool _stage3_score)
    {


        stage3_score = _stage3_score;
    }


    //setしたいset関数
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

    //戻り値をgetしたいget関数
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
 セットとゲットの関数

    セット。。。
     
     */