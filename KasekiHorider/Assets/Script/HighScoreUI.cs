using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {
    [SerializeField]
    private Text text;

	// Use this for initialization
	void Start () {
        this.text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "HighScore: " + ScoreManager.highScore;
	}
}
