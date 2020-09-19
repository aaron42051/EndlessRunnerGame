using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A script attached to platforms to tell them 
 * when to deactivate
 *
 *
 */

public class ObjectDestroyer : MonoBehaviour {

    // point at which to deactivate (follows behind player)
    public GameObject objectDestructionPoint;

    // the pool to return the object to
    private ObjectPooler objectPoolerComponent;

    private int length;

    void Start () {
        objectDestructionPoint = GameObject.Find("ObjectDestructionPoint");
        objectPoolerComponent = transform.parent.gameObject.GetComponent<ObjectPooler>();
    }
	

	void Update () {

        // if this object has passed the platformDestructionPoint, deactivate it in its pool
		if (transform.position.x < objectDestructionPoint.transform.position.x)
        {
            objectPoolerComponent.DeactivatePoolObject();
        }
	}
}
