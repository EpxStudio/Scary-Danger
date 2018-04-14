using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAnimation : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.StopPlayback();
        anim.speed = 25;
	}
	
	// Update is called once per frame
	void Update () {
        anim.Play("Take 001");
    }
}
