using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    GameObject limitTimeUI;
    public float time = 120.0f;
    public bool isStopped { set; get; }


    [SerializeField]
    private AudioClip clip;

    // Use this for initialization
    void Start()
    {
        this.limitTimeUI = GameObject.Find("LimitTime");
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.O))
        {
            time = 5;
        }
#endif
        // 毎フレーム毎に残り時間を減らしていく
        if(!isStopped)
        {
            this.time -= Time.deltaTime;
        }
        if (this.time < 0)
        {
            //this.limitTimeUI.GetComponent<Text>().text = "終了";完了したのでコメントアウト
            AudioManager.instance.PlaySE(clip);
            FloorManager.instance.ResetFloor();
            ScoreManager.Save();
            SceneManager.LoadScene("ResultScene");
        }
        else
        {
            // timeを文字列に変換したものをテキストに表示する
            // ToStringのF1とは、小数点以下1桁までという意味
            this.limitTimeUI.GetComponent<Text>().text = this.time.ToString("F1");
        }
    }
   
   public float GetTime()
    {
        return time;
    }

    public void SetTime(float time)
    {
        this.time = time;
    }

}
