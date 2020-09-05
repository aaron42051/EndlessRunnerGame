using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager scoreManager;

    private AudioSource coinSound;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("Coin Sound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            } else
            {
                coinSound.Play();
            }

            gameObject.SetActive(false);
            scoreManager.AddScore(scoreToGive);
        }
    }
}
