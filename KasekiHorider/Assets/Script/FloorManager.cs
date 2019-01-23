using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorManager : MonoBehaviour
{

    public static FloorManager instance { private set; get; }


    public int floorIndex { private set; get; }

    public float saveTime { private set; get; }

    private TimeScript timeScript;
    private bool restoreTime;
    private bool fadeNow;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        //この部分の処理を LoadScene の後に書くほうが簡潔ですが、
        //それだと動作しなかったのでこうしています。
        //(コルーチンと相性が悪いのかもしれません。)
        if (restoreTime)
        {
            CacheTimeScript();
            timeScript.SetTime(saveTime);
            this.restoreTime = false;
        }
    }

    /// <summary>
    /// フロア番号をリセット
    /// </summary>
    public void ResetFloor()
    {
        this.floorIndex = 0;
    }

    /// <summary>
    /// 次のフロアへ
    /// </summary>
    public void NextFloor()
    {
        if(fadeNow) { return; }
        StartCoroutine(StartFade());
    }
    private void CacheTimeScript()
    {
        var timeObject = GameObject.Find("TimeObject");
        if (timeObject != null)
        {
            Debug.Log("TimeObject Update");
            this.timeScript = timeObject.GetComponent<TimeScript>();
        }
        else
        {
            Debug.LogError("TimeObject not found");
        }
    }


    private IEnumerator StartFade()
    {
        //フェード中はフリーズ
        this.fadeNow = true;
        CacheTimeScript();
        timeScript.isStopped = true;
        yield return FadeUI.instance.StartAnimation(1f, (e) => e);
        //シーンをロードしたあとの最初の
        //Updateで元に戻す。
        this.saveTime = timeScript.GetTime();
        this.restoreTime = true;
        floorIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForEndOfFrame();
        yield return FadeUI.instance.StartAnimation(1f, (e) => 1 - e);
        this.fadeNow = false;
    }
}
