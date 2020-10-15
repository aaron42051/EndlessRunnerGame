using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    // platforms (and everything that goes with a platform)
    [Header("Platform Generation")]
    public Transform generationPoint;

    private float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler[] platformPools;
    private int platformSelector;
    private int platformsUnlocked = 2;
    private float[] platformWidths;


    public Transform maxHeightPoint;
    private float minHeight;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    [Header("Coins")]
    // coins
    public CoinGenerator coinGenerator;
    public float randomCoinThreshold;

    [Header("Spikes")]
    // spikes
    public ObjectPooler spikePool;
    public float randomSpikeThreshold;

    [Header("Powerups")]
    // powerups
    public PowerupManager powerupManager;
    public ObjectPooler[] powerupPools;
    private int powerupSelector;
    public float powerupHeight;
    public float randomPowerupThreshold;


	void Start () {

        InstantiateWidths();

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

	}
	

	void Update () {

        // if we pass generation point
        // Note: position changes so order of generation matters
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, platformsUnlocked);


            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            GeneratePowerup();

            // move generator (this) to new platform position and generate platform
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2)  + distanceBetween, heightChange, transform.position.z);

            GeneratePlatform();

            GenerateCoins();

            if (!powerupManager.GetSafeMode())
            {
                GenerateSpikes();
            }

            // this is moving the generator to the edge of the new platform
            // prepping for the next platform to spawn
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }

    public void SetSpikesThreshold(float threshold)
    {
        randomSpikeThreshold = threshold;
    }
    
    public void MultiplyHeightChange(float multiplier)
    {
        maxHeightChange *= multiplier;
    }

    public void AddUnlockedPlatform(int value)
    {
        platformsUnlocked += value;
    }

    void InstantiateWidths()
    {
        platformWidths = new float[platformPools.Length];

        // for each object platform pooler, set the platform width
        for (int i = 0; i < platformPools.Length; i++)
        {
            platformWidths[i] = platformPools[i].poolObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    void GeneratePowerup()
    {
        // generate powerup in between platforms
        if (Random.Range(0f, 100f) < randomPowerupThreshold)
        {

            GameObject newPowerup = powerupPools[Random.Range(0, powerupPools.Length)].ActivatePoolObject();

            newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2, powerupHeight, 0f);

        }
    }

    void GenerateCoins()
    {
        // generate coins on top of the new platform
        if (Random.Range(0f, 100f) < randomCoinThreshold)
        {
            coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), 4); // num coins
        }
    }

    void GenerateSpikes()
    {
        if (Random.Range(0f, 100f) < randomSpikeThreshold)
        {
            GameObject newSpike = spikePool.ActivatePoolObject();

            float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2 + 1f, platformWidths[platformSelector] / 2 - 1f);

            Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

            newSpike.transform.position = transform.position + spikePosition;
            newSpike.transform.rotation = transform.rotation;
            newSpike.SetActive(true);
        }
    }

    void GeneratePlatform()
    {
        GameObject newPlatform = platformPools[platformSelector].ActivatePoolObject();
        newPlatform.transform.position = transform.position;
        newPlatform.transform.rotation = transform.rotation;
        newPlatform.SetActive(true);
    }
}
