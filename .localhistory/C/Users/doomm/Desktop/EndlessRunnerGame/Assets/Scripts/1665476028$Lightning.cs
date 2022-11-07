using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public float speed;
    private bool didHit = false;
	
	void Update () {
        transform.position -= new Vector3(0, speed, 0);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
