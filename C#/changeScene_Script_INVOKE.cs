using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene_Script_INVOKE : MonoBehaviour
{

    string sceneName;
    buttonmanager bm;
   
    public void LoadScene2(string str)
    {

        GameObject o = GameObject.Find("Main Camera");      //オブジェクトみつける
        buttonmanager bm = o.GetComponent<buttonmanager>();

        if (bm != null)
        {
            if (bm.Button_state == 1)    //もし、1の時、ロックかける
            {
                return;
            }

        }

        bm.Button_state = 1;　//ロック！

        sceneName = str;    //インボック関数は他の所から呼べないからグローバル変数で宣言
        Invoke("AAAA", 1.0f);
    }
    void AAAA()
    {
        SceneManager.LoadScene(sceneName);    //シーンを読み込む
    }

    //シーンをロードする
    public void LoadScene(string str)
    {
        

        if (bm.Button_state == 1)
        {
            return;
        }
        SceneManager.LoadScene(str);    //シーンを読み込む

    }

        //ゲームを終了する
        public void GameEnd()
        {
#if UNITY_EDITOR    // unityeditorでの実行なら
            
          //再生モードを解除する 

          UnityEditor.EditorApplication.isPlaying = false;

#else   //  unityeditorでの実行ではなければ（→ビルド後）なら

            Application.Quit();

#endif

        }
    }


   
    //void (){
    // changeScene_Script_INVOKE      

