using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {


    public enum PowerupType
    {
        DoublePoints,
        SafeMode,
        Lightning
    }


    public PowerupType power;

    public float powerupLength;

    private PowerupManager powerupManager;


	// only happens the first time this thing is ever created
	void Start () {
        powerupManager = FindObjectOfType<PowerupManager>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            powerupManager.ActivatePowerup(power, powerupLength);
        }
        gameObject.SetActive(false);
    }
}
