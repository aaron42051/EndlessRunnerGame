using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool isAlive;

    public bool shouldDouble;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (isAlive)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount); // not sure we have to do this every frame
		
	}

    public void AddScore(int pointsToAdd)
    {
        if (shouldDouble)
        {
            pointsToAdd += pointsToAdd;
        }

        scoreCount += pointsToAdd;
    }
}
