using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigEffectManager : MonoBehaviour {

    public GameObject DigEffect;
    float timer = 0f;
    public float NoCallTime = 0.05f;

    Object lockObj;
	// Use this for initialization
	void Start () {
        timer = 0f;
        lockObj = new Object();
    }
	
	// Update is called once per frame
	void Update () {
        timer = Mathf.Max(0f, timer - Time.deltaTime);
	}

    public bool callEffect(Vector3 pos)
    {
        if(timer > 0f)
        {
            return false;
        }

        lock (lockObj)
        {
            timer = NoCallTime;

            Instantiate(DigEffect, pos, Quaternion.identity);

            return true;
        }

    }
}
