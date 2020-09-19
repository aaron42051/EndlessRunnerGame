using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager scoreManager;

    private AudioSource coinSound;

	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("Coin Sound").GetComponent<AudioSource>();
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
