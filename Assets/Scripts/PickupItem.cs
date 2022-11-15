using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager scoreManager;

    private AudioSource soundEffect;

    public string soundEffectName;

    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        soundEffect = GameObject.Find(soundEffectName).GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (soundEffect.isPlaying)
            {
                soundEffect.Stop();
                soundEffect.Play();
            } else
            {
                soundEffect.Play();
            }

            gameObject.SetActive(false);
            scoreManager.AddScore(scoreToGive);
        }

    }
}
