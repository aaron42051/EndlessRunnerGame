using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject poolObject;

    public int poolCount;

    private Stack<GameObject> availablePool;

    private Queue<GameObject> inUsePool;


	void Start () {

        inUsePool = new Queue<GameObject>();
        availablePool = new Stack<GameObject>();


        // fill the pool with objects
        for (int i = inUsePool.Count; i < poolCount; i++)
        {
            GameObject newPoolObj = Instantiate(poolObject);
            newPoolObj.SetActive(false);
            availablePool.Push(newPoolObj);
            newPoolObj.transform.SetParent(this.transform);

        }
    }
	

    public GameObject ActivatePoolObject()
    {
        GameObject newPoolObj;

        // we have an available object, pop it out, activate, and push to inUse
        if (availablePool.Count > 0)
        {
            newPoolObj = availablePool.Pop();
            newPoolObj.SetActive(true);
            inUsePool.Enqueue(newPoolObj);
        }

        // we are out of pool objects, make and add a new one
        else
        {
            newPoolObj = Instantiate(poolObject);
            inUsePool.Enqueue(newPoolObj);
            newPoolObj.transform.SetParent(this.transform);
        }

        return newPoolObj;
    }

    public void DeactivatePoolObject()
    {
        // remove the last object, deactivate, put it back in the availablePool
        GameObject oldObject = inUsePool.Dequeue();
        oldObject.SetActive(false);
        availablePool.Push(oldObject);

    }

    public void DeactivateAllObjects()
    {
        while(inUsePool.Count > 0)
        {
            DeactivatePoolObject();
        }
    }

    public Queue<GameObject> GetInUsePool()
    {
        return inUsePool;
    }
}
