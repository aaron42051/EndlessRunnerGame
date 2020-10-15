using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public GameObject player;
    private PlayerController playerController;

    public float speedUpMultiplier;

    public float milestoneDistance;
    private float initialMilestoneDistance;

    private float currentMilestone;

    public ScoreManager scoreManager;

    // Use this for initialization
    void Start () {
        currentMilestone = milestoneDistance;
        initialMilestoneDistance = milestoneDistance;

        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update () {
        if (player.activeSelf)
        {
            checkSpeedUpMilestone();
        }

    }

    void checkSpeedUpMilestone()
    {

        // speed up milestones
        if (player.transform.position.x > currentMilestone)
        {
            Debug.Log("speeding up!");
            Debug.Log(player.transform.position.x);
            // set the next speed up point, increase distance to the next point, increase player speed
            milestoneDistance = milestoneDistance * speedUpMultiplier;
            currentMilestone += milestoneDistance;
            playerController.MultiplySpeed(speedUpMultiplier);

            // increase the rate of score gain as well
            scoreManager.MultiplyScoreMultiplier(speedUpMultiplier);
        }
    }

    public void resetMilestones()
    {
        currentMilestone = initialMilestoneDistance;
        milestoneDistance = initialMilestoneDistance;
    }
}
