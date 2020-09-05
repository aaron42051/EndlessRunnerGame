using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public bool doublePoints;
    public bool safeMode;

    public float powerupLength;
    private PowerupManager powerupManager;

    public Sprite[] powerupSprites;

	// only happens the first time this thing is ever created
	void Start () {
        powerupManager = FindObjectOfType<PowerupManager>();
	}

    // happens everytime this becomes active
    private void Awake()
    {
        int powerupSelector = Random.Range(0, 2);

        switch(powerupSelector)
        {
            case 0:
                doublePoints = true;
                break;
            case 1:
                safeMode = true;
                break;
            default:
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            powerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
        }
        gameObject.SetActive(false);
    }
}
