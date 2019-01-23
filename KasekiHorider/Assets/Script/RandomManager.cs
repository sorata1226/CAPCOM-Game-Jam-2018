using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour {

    System.Random rnd;

    // Use this for initialization
    void Start ()
    {
        rnd = new System.Random(System.Environment.TickCount);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float NextFloat()
    {
        return (float)rnd.NextDouble();
    }
}
