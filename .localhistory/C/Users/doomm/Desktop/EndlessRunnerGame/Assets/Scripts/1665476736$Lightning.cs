﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public float speed;
    private bool didHit = false;
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // move straight down
    void Update () {
        transform.position -= new Vector3(0, speed, 0);
	}

    // on collision, set the animation
    public void onHit()
    {
        myAnimator.SetBool("didHit", true);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}