using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private Animator animator;
    private string lastAnimation;


    [SerializeField]
    private bool debugMode = true;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
    }
    //WalkFront
    public void StartWalkFront()
    {
        SetAnimation("WalkFront", true);
    }

    public void StopWalkFront()
    {
        SetAnimation("WalkFront", false);
    }
    //WalkBack
    public void StartWalkBack()
    {
        SetAnimation("WalkBack", true);
    }

    public void StopWalkBack()
    {
        SetAnimation("WalkBack", false);
    }
    //WalkLeft
    public void StartWalkLeft()
    {
        SetAnimation("WalkLeft", true);
    }

    public void StopWalkLeft()
    {
        SetAnimation("WalkLeft", false);
    }
    //WalkRight
    public void StartWalkRight()
    {
        SetAnimation("WalkRight", true);
    }

    public void StopWalkRight()
    {
        SetAnimation("WalkRight", false);
    }

    private void SetAnimation(string name, bool b)
    {
        animator.SetBool("WalkFront", false);
        animator.SetBool("WalkBack", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);
        animator.SetBool(name, b);
    }
}
