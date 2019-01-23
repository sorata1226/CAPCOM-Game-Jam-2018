using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankUI : MonoBehaviour {
    [SerializeField]
    private Text text;

	// Use this for initialization
	void Start () {
		if(text == null)
        {
            this.text = GetComponentInChildren<Text>();
        }
        text.text = ScoreManager.ScoreToString();
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("random score");
            ScoreManager.DebugRandom();
            text.text = ScoreManager.ScoreToString();
        }
#endif
    }
}
