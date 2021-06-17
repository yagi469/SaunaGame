using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_M : MonoBehaviour
{
    //1‚Â–Ú‚ÌText
    public RectTransform text1;
    //‚Q‚Â–Ú‚ÌText
    public RectTransform text2;

    public RectTransform canvas;




    // Start is called before the first frame update
    void Start()
    {
        //ƒQ[ƒ€‰æ–Ê‚Ì‰¡•‚Æc•‚ÌƒsƒNƒZƒ‹
        //Debug.Log("Screen Width : " + Screen.width);
        //Debug.Log("Screen  height: " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {

        //–ˆ•b ‰½f‚¸‚Â“®‚©‚·‚©
       text1.position += new Vector3(-0.2f, 0f, 0f);
        text2.position += new Vector3(-0.2f, 0f, 0f);
       //Debug.Log("text1.x" + text1.position.x);
       // Debug.Log("text2.x" + text2.position.x);



        //‚à‚µAtext1‚Ìposition.x‚ª0‚Ì
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
