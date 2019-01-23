using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSE : MonoBehaviour {
    [SerializeField]
    private AudioClip clip;

	// Use this for initialization
	void Start () {
        AudioManager.instance.PlaySE(clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
