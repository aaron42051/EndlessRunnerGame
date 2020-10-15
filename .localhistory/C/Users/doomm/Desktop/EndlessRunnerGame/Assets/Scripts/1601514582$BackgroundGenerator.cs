using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public Transform generationPoint;
    public ObjectPooler backgroundPooler;
	
    // position this object at the edge of the last background

	void Update () {
		if (transform.position.x < generationPoint.position.x)
        {
            
        }
	}
}
