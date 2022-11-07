using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for controlling power up effects
public class PowerupManager : MonoBehaviour {


    // fields affected by powerups
    private bool safeMode = false;

    // managers affected by powerups
    public ScoreManager scoreManager;

    public ObjectGenerator objectGenerator;

    public ObjectPooler spikePooler;

    public ObjectPooler lightningPooler;

    public ObjectPooler enemyPooler;

    public GameManager gameManager;

    private List<PowerupTimer> powerupTimers;

    class PowerupTimer
    {
        private float currentTime;
        private Powerup.PowerupType power;

        public PowerupTimer(float t, Powerup.PowerupType p)
        {
            currentTime = t;
            power = p;
        }

        public float GetTimer()
        {
            return currentTime;
        }

        public Powerup.PowerupType GetPower()
        {
            return power;
        }

        public void SetTimer(float time)
        {
            currentTime = time;
        }
    }

    // get the scripts from the objects
    void Start () {
        powerupTimers = new List<PowerupTimer>();
	}
	
	// Run all powerup timers down
	void Update () {

        if (powerupTimers.Count > 0)
        {
            for (int i = 0; i < powerupTimers.Count;)
            {
                PowerupTimer timer = powerupTimers[i];

                timer.SetTimer(timer.GetTimer() - Time.deltaTime);
                if (timer.GetTimer() <= 0)
                {
                    powerupTimers.Remove(timer);
                    DeactivatePowerup(timer.GetPower());
                }
                else
                {
                    i += 1;
                }
            }

        }

    }


    public bool GetSafeMode()
    {
        return safeMode;
    }

    public void ActivatePowerup(Powerup.PowerupType power, float time)
    {

        switch(power)
        {
            case Powerup.PowerupType.DoublePoints:
                scoreManager.MultiplyScoreMultiplier(2);
                powerupTimers.Add(new PowerupTimer(time, power));
                break;

            case Powerup.PowerupType.SafeMode:
                // if safe mode is already on, refresh the timer
                if (safeMode)
                {
                    foreach(PowerupTimer timer in powerupTimers)
                    {
                        if (timer.GetPower() == Powerup.PowerupType.SafeMode)
                        {
                            timer.SetTimer(time);
                        }
                    }
                }
                else
                {
                    spikePooler.DeactivateAllObjects();
                    powerupTimers.Add(new PowerupTimer(time, power));
                    safeMode = true;
                }
                break;
            case Powerup.PowerupType.Lightning:
                GenerateLightning();
                break;
            default:
                break;
        }
    }

    public void DeactivatePowerup(Powerup.PowerupType power)
    {
        switch(power)
        {
            case Powerup.PowerupType.DoublePoints:
                scoreManager.MultiplyScoreMultiplier(0.5f);
                break;
            case Powerup.PowerupType.SafeMode:
                safeMode = false;
                break;
            default:
                break;
        }
    }

    public void ResetPowerups()
    {
        if (powerupTimers.Count > 0)
        {
            // loop through and undo the powerups
            for (int i = 0; i < powerupTimers.Count; i++)
            {
                PowerupTimer timer = powerupTimers[i];

                switch (timer.GetPower())
                {
                    case Powerup.PowerupType.DoublePoints:
                        scoreManager.MultiplyScoreMultiplier(0.5f);
                        break;
                    case Powerup.PowerupType.SafeMode:
                        safeMode = false;
                        break;
                    default:
                        break;
                }
            }
            powerupTimers.Clear();
        }
    }


    public void GenerateLightning()
    {
        // get all enemies currently in use and spawn lightning above them
        Queue<GameObject> enemyPool = enemyPooler.GetInUsePool();

        foreach(GameObject enemy in enemyPool)
        {
            GameObject l = lightningPooler.ActivatePoolObject();
            float x = enemy.transform.position.x;
            l.transform.position = new Vector3(x, 3.0f, 0);
        }
    }

}
