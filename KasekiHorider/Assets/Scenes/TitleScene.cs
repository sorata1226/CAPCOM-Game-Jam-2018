using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject FadeObject;
    public int floorIndex { private set; get; }

    private void Awake()
    {
        ScoreManager.ResetScore();
        ScoreManager.Load();
    }
    void Start ()
    {
        //SceneManager.LoadSceneAsync("GameScene");
    }
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeScene();
            //   StartCoroutine(StartFade());
        }
        //if (floorIndex >= 1)
        //{
        ////StartCoroutine(StartFade());
        //    ChangeScene();
        //}
    }
    void ChangeScene()
    {
        FloorManager.instance.ResetFloor();
        SceneManager.LoadScene("GameScene");
    }
    private IEnumerator StartFade()
    {
        yield return FadeUI.instance.StartAnimation(1f, (e) => e);
        floorIndex++;
        yield return FadeUI.instance.StartAnimation(1f, (e) => 1 - e);
    }

}
