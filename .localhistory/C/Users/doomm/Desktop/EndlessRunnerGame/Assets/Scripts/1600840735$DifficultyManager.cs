using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public GameObject player;
    private PlayerController playerController;

    public float speedUpMultiplier;

    public float speedUpMilestone;
    private float speedUpMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public ScoreManager scoreManager;

    // Use this for initialization
    void Start () {
        speedMilestoneCount = speedUpMilestone;
        speedMilestoneCountStore = speedMilestoneCount;
        speedUpMilestoneStore = speedUpMilestone;

        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update () {
        checkMilestone();
	}

    void checkMilestone()
    {

        if (player.transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedUpMilestone;
            speedUpMilestone = speedUpMilestone * speedUpMultiplier;
            playerController.MultiplySpeed(speedUpMultiplier);

            // make sure to increase the rate of score gain as well
            
        }
    }

    void resetMilestones()
    {
        speedMilestoneCount = speedMilestoneCountStore;
        speedUpMilestone = speedUpMilestoneStore;
    }
}
