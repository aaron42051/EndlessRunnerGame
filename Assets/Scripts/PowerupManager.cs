using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager scoreManager;
    private PlatformGenerator platformGenerator;

    private float normalPointsPerSecond;
    private float normalSpikeThreshold;

    private ObjectPooler spikePooler;

    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        platformGenerator = FindObjectOfType<PlatformGenerator>();
        spikePooler = GameObject.Find("SpikePool").GetComponent<ObjectPooler>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (gameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                gameManager.powerupReset = false;
            }

            if (doublePoints)
            {
                scoreManager.pointsPerSecond = normalPointsPerSecond * 2; // only do this once? this will currently double the pps again if another power up is picked up
                scoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                platformGenerator.randomSpikeThreshold = 0;
                spikePooler.DeactivateAllPlatforms();
            }
            
            if (powerupLengthCounter <= 0)
            {
                ResetPowerups();
            }
        }
	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = scoreManager.pointsPerSecond;
        normalSpikeThreshold = platformGenerator.randomSpikeThreshold;

        powerupActive = true;
    }

    public void ResetPowerups()
    {
        powerupActive = false;
        scoreManager.pointsPerSecond = normalPointsPerSecond;
        scoreManager.shouldDouble = false;
        platformGenerator.randomSpikeThreshold = normalSpikeThreshold;
    }
}
