using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public GameObject FadeObject;
    public int Score;
    // Use this for initialization
    void Start ()
    {
     //   SceneManager.LoadSceneAsync("TitleScene");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Score = ScoreManager.GetScore();
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("TitleScene");

    }
}
