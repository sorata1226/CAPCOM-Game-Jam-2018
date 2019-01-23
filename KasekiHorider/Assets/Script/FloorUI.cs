using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorUI : MonoBehaviour {
    [SerializeField]
    private Text text;
	// Use this for initialization
	void Start () {
		if(text == null)
        {
            this.text = GetComponentInChildren<Text>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Floor:" + FloorManager.instance.floorIndex;
	}
}
