using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene_Script : MonoBehaviour
{

   

    //シーンをロードする
    public void LoadScene(string str)
    {



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