using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager_Scene3 : MonoBehaviour
{
    //タイマー用変数
    public float LimitTime;                   //タイマーの設定時間
    private bool counting;　　　　　　　　　　//タイマー稼働フラグ

    //プログレスバー用変数
    public Slider slider;                     //Sliderオブジェクト
    private float PaintSpeed;                 //塗りつぶし速度用変数


    void Start()

    // Start is called before the first frame update
    {
        //塗りつぶし速度の設定
        PaintSpeed = LimitTime;
    }

    // Update is called once per frame
    void Update()
    {
        {
            TimerCount();
        }
    }

    //タイマー機能
    void TimerCount()
    {
        //稼働時の経過時間
        LimitTime -= Time.deltaTime;

        ProgressMove();

        //タイマーの停止
        if (LimitTime <= 0)
        {
            counting = false;
        }

        //countdownが0以下になったとき
        if (LimitTime <= -2)
        {
            SceneManager.LoadScene("Scene_result");
        }
       
    }
    //プログレスバー処理
    void ProgressMove()
    {
        //経過時間から移動量の計算
        float amount = Time.deltaTime / PaintSpeed;

        //スライダーの移動量を代入
        slider.value -= amount;
    }

    //タイマースタート
    public void PushStart()
    {
        counting = true;
    }
}

/* http://kerotan-factory.xblog.jp/article/473783356.html */
