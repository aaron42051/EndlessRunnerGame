using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public Transform generationPoint;

    private float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] objectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;

    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator coinGenerator;

    public float randomCoinThreshold;


	void Start () {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        // instantiate array of platform widths
        platformWidths = new float[objectPools.Length];

        // for each object platform pooler, set the platform width
        for (int i = 0; i < objectPools.Length; i++)
        {
            platformWidths[i] = objectPools[i].poolObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<CoinGenerator>();

	}
	

	void Update () {

        // if the platform generator is behind the generation point, make a new platform and move this forward
        if (transform.position.x < generationPoint.position.x)
        {
            // pick a random distance between platforms
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            // make a random number to pick which platform type to pick
            platformSelector = Random.Range(0, objectPools.Length);

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2)  + distanceBetween, heightChange, transform.position.z);

            GameObject newPlatform = objectPools[platformSelector].ActivatePoolObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), 4);
            }

            // this is movement is moving the generator to the edge of the new platform
            // prepping for the next platform to spawn
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


        }
    }
}
