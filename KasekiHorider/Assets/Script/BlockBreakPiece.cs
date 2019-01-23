using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreakPiece : MonoBehaviour {
    float _speed = 1.5f;
    
    Vector3 velocity;
    
    RandomManager rnd;

    // Use this for initialization
    void Start ()
    {
        rnd = GameObject.Find("Random").GetComponent<RandomManager>();
        float rad = 2f * Mathf.PI * rnd.NextFloat();
        velocity = new Vector3(_speed * Mathf.Cos(rad), _speed * Mathf.Sin(rad));
	}
	
	// Update is called once per frame
	void Update () {
        // 計算が正確じゃないけど許して.
        transform.position += velocity * Time.deltaTime;
    }
}
