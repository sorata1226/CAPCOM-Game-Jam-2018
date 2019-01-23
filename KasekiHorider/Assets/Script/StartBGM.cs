using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGM : MonoBehaviour {
    [SerializeField]
    private AudioClip clip;

	// Use this for initialization
	void Start () {
        AudioManager.instance.PlayBGM(clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        AudioManager.instance.StopBGM();
    }
}
