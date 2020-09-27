using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public GameObject player;
    private PlayerController playerController;

    public float speedUpMultiplier;

    public float speedUpPointDistance;
    private float initialMilestoneDistance;

    private float currentSpeedUpMilestone;

    public ScoreManager scoreManager;

    // Use this for initialization
    void Start () {
        currentSpeedUpMilestone = speedUpPointDistance;
        initialMilestoneDistance = speedUpPointDistance;

        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update () {

            checkSpeedUpMilestone();
        
    }

    void checkSpeedUpMilestone()
    {

        // speed up milestones
        if (player.transform.position.x > currentSpeedUpMilestone)
        {
            Debug.Log("speeding up!");
            Debug.Log(player.transform.position.x);
            // set the next speed up point, increase distance to the next point, increase player speed
            speedUpPointDistance = speedUpPointDistance * speedUpMultiplier;
            currentSpeedUpMilestone += speedUpPointDistance;
            playerController.MultiplySpeed(speedUpMultiplier);

            // increase the rate of score gain as well
            scoreManager.MultiplyScoreMultiplier(speedUpMultiplier);
        }
    }

    void resetMilestones()
    {
        currentSpeedUpMilestone = initialMilestoneDistance;
        speedUpPointDistance = initialMilestoneDistance;
    }
}
