using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGemEffect : MonoBehaviour {
    public GameObject player { set; get; }
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1f);	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}
}
