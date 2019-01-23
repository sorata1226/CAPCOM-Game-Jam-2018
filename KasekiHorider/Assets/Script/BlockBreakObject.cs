using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreakObject : MonoBehaviour {

    public float LifeTime = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LifeTime -= Time.deltaTime;
        if(LifeTime <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
