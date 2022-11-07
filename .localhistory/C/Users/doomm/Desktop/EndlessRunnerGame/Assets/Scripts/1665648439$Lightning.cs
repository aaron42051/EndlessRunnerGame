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

    // move straight down until collision
    void Update () {

        if (!didHit)
        {
            Debug.Log("moving")
            transform.position -= new Vector3(0, speed, 0);
        }
    }

    // on collision, play the animation then disappear
    public IEnumerator OnHit()
    {
        Debug.Log("On Hit");

        didHit = true;

        myAnimator.SetBool("didHit", true);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
