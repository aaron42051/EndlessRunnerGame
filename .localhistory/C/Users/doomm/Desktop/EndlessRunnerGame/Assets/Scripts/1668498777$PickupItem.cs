using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager scoreManager;

    public GameObject soundEffect;
    private AudioSource soundComponent;

    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        soundComponent = soundEffect.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (soundComponent.isPlaying)
            {
                soundComponent.Stop();
                soundComponent.Play();
            } else
            {
                soundComponent.Play();
            }

            gameObject.SetActive(false);
            scoreManager.AddScore(scoreToGive);
        }

    }
}
