using System.Collections;
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

    void Update () {
        transform.position -= new Vector3(0, speed, 0);
	}

    public void onHit()
    {

    }
}
