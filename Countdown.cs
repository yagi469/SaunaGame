using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private Text _textCountdown;

    [SerializeField]
    private Image _imageMask;

    void Start()
    {
        _textCountdown.text = "";
    }

    public void OnClickButtonStart()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        _imageMask.gameObject.SetActive(true);
        _textCountdown.gameObject.SetActive(true);

        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        _textCountdown.gameObject.SetActive(false);
        _imageMask.gameObject.SetActive(false);
    }
}

/* 
  
  http://narudesign.com/devlog/unity-countdown-display/
 
    https://qiita.com/ogawa-to/items/be474429b87ad9072e45

    https://nn-hokuson.hatenablog.com/entry/2017/05/29/204702

    https://tech.pjin.jp/blog/2018/10/24/unity_scene-manager_event/#10
 
     
     
     
     
     
     
     
     */
