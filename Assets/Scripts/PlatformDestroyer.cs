using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A script attached to platforms to tell them 
 * when to deactivate
 *
 *
 */

public class PlatformDestroyer : MonoBehaviour {

    // point at which to deactivate (follows behind player)
    public GameObject platformDestructionPoint;

    // the pool to return the object to
    private ObjectPooler objectPool;
    public GameObject ObjectPooler;

    private int length;

    void Start () {

        if (gameObject.name.Contains("Platform"))
        {
            // find the right object pooler using length
            length = (int)GetComponent<BoxCollider2D>().size.x;
            ObjectPooler = GameObject.Find("ObjectPooler " + length + "x1");
            objectPool = ObjectPooler.GetComponent<ObjectPooler>();
            platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        }
        else if (gameObject.name.Contains("Coin"))
        {
            ObjectPooler = GameObject.Find("CoinPool");
            objectPool = ObjectPooler.GetComponent<ObjectPooler>();
            platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        }

	}
	

	void Update () {

        // if this object has passed the platformDestructionPoint, deactivate it in its pool
		if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            objectPool.DeactivatePoolObject();
        }
	}
}
