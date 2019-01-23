using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour {
    GameObject Target;
    Vector3 StartPos;
    float distance = 0f;
    public float Speed = 10f;
    Vector3 velocity;

    public string TargetName;

	// Use this for initialization
	void Start () {
        Target = GameObject.Find(TargetName);
        StartPos = gameObject.transform.position;
        distance = (Target.transform.position - StartPos).magnitude;
        velocity = (Target.transform.position - StartPos);
        velocity.Normalize();
        velocity *= Speed;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += velocity * Time.deltaTime;
        distance -= Speed * Time.deltaTime;
        if(distance <= 0f)
        {
            Destroy(gameObject);
        }

    }
}
