using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public Transform generationPoint;
    public ObjectPooler backgroundPooler;
	
    // position this object past the position of the last Starting Background

	void Update () {
		if (transform.position.x < generationPoint.position.x)
        {
            GameObject newBackground = backgroundPooler.ActivatePoolObject();
            newBackground.transform.position = transform.position;

            transform.position = new Vector3(transform.position.x + newBackground.GetComponent<BoxCollider2D>().size.x, transform.position.y, transform.position.z);
        }
	}
}
