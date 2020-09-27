 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    private float scoreCount;
    private float highScoreCount;

    public float pointsPerSecond;

    private bool isAlive = true;
    private float scoreMultiplier = 1;

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
            scoreCount += pointsPerSecond * Time.deltaTime * scoreMultiplier;
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
        scoreCount += pointsToAdd * scoreMultiplier;
    }

    public void MultiplyScoreMultiplier(float multiplier)
    {
        scoreMultiplier *= multiplier;
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    public void ResetScore()
    {
        scoreCount = 0;
        isAlive = true;
    }
}
