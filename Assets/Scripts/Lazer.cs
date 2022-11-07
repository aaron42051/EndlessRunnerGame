using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {

    public float speed;

	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed, 0, 0);
	}
}
