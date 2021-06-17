using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class scoreScript : MonoBehaviour
{
    // public Text scoreText; //Text用変数
   
        //enemy1のスコア
    public static int score = 0;
        //wm
    public static int score2 = 0;
    public static int score3 = 0;


}
//    void Start()
//    {

//        SetScore();   //初期スコアを代入して表示
//    }

//    //cube同士での衝突＋100 cube以外との衝突＋100
//    void OnCollisionEnter(Collision collision)
//    {
//        string yourTag = collision.gameObject.tag;

//        if (yourTag == "Bullet")
//        {
//            score += 100;
//        }


//        SetScore();
//    }

//    void SetScore()
//    {
//     //   scoreText.text = string.Format("Score:{0}", score);
//    }
//}

/*  void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy1")
        {
            HitCount++;
            if (HitCount >= 3)
            {
                SceneManager.LoadScene("result_Scene");
            }
        }

    }
}
*/
