using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayResult : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //シーンがresultに移動したときのカーソルをtrueに変え,表示させる
        //Cursor.visible = true;
        //カーソルのアンロック
        //Cursor.lockState = CursorLockMode.None;


        float res = scoreScript.score; //scoreScriptスクリプトのscoreを取得
        float res2 = scoreScript.score2; //scoreScriptスクリプトのscoreを取得
        float res3 = scoreScript.score3; //scoreScriptスクリプトのscoreを取得

        //float res = DataScript.stage1_score; //scoreScriptスクリプトのscoreを取得
        //float res2 = DataScript.stage2_score; //scoreScriptスクリプトのscoreを取得
        //float res3 = DataScript.stage3_score; //scoreScriptスクリプトのscoreを取得

        float res4 = res + res2 + res3;

        //値を文字列にする
        string mes = "あなたのスコアは" + res4.ToString("0000") + "でした！";

        //**けん、＊＊し、＊＊丁みたいに書く→scoreScriptの中にあるTextの中にあるText
        this.GetComponent<Text>().text = mes;       //文字列を表示
    }

    // Update is called once per frame
    void Update()
    {

    }
}

