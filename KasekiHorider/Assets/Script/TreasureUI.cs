using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureUI : MonoBehaviour {
    public string UIName;
	// Use this for initialization
	void Start () {
        var target = GameObject.Find(UIName);
        var pos = Camera.main.ScreenToWorldPoint(target.transform.position);
        gameObject.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
