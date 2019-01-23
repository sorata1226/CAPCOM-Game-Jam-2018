using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {
    [SerializeField]
    public int score = 3;

    public GameObject GetTreasure;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyTreasure()
    {
        GameObject obj = Instantiate(GetTreasure, transform.position, transform.rotation);
        obj.transform.parent = GameObject.Find("Main Camera").transform;
        GameObject.Destroy(gameObject);
    }
}
