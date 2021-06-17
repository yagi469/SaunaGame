using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    //タイマー用変数
    public float LimitTime;                   //タイマーの設定時間
    private bool counting;　　　　　　　　　　//タイマー稼働フラグ

    //プログレスバー用変数
    //public GameObject CircleProgress;         //円タイプのプログレスバー
    //private Image circle;                     //CircleProgressのImage取得用
    //private float PaintSpeed;                 //塗りつぶし速度用変数

    //プログレスバー用変数
    public Slider slider;                     //Sliderオブジェクト
    private float PaintSpeed;                 //塗りつぶし速度用変数


    //整ったらtrue,
    public bool resultFg = false;

    void Start()
   


    // Start is called before the first frame update
    {
        //CircleProgressのImageコンポーネント取得
        //circle = CircleProgress.GetComponent<Image>();
        //塗りつぶし速度の設定
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
        if (LimitTime <= -5)
        {
            SceneManager.LoadScene("Scene2");
        }

        //もし、ボタンが押された時＆＆LimitTimeが40～55の時
        if (Input.GetMouseButtonDown(0) && LimitTime <= 40 && LimitTime >= 55)
        {
            resultFg = true;
        }
        else
        {
            resultFg = false;
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

    //プログレスバー処理
    //void ProgressMove()
    //{
    //    //経過時間から塗りつぶし量を計算
    //    float amount = Time.deltaTime / PaintSpeed;

    //    //塗つぶし量を代入する
    //    circle.fillAmount += amount;
    //}

    //タイマースタート
    public void PushStart()
    {
        counting = true;
    }

    
}

/* http://kerotan-factory.xblog.jp/article/473783356.html */
