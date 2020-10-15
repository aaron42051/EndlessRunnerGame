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

    private Milestones milestones;
    private Dictionary<MilestoneType, float>[] milestoneList;
    private int milestoneIndex = 0;

    public ObjectGenerator objectGenerator;

    // Use this for initialization
    void Start () {
        currentMilestone = milestoneDistance;
        initialMilestoneDistance = milestoneDistance;

        playerController = player.GetComponent<PlayerController>();

        milestones = new Milestones();
        milestoneList = milestones.MilestoneList;
    }

    // Update is called once per frame
    void Update () {
        if (player.activeSelf)
        {
            CheckSpeedUpMilestone();
        }

    }

    void CheckSpeedUpMilestone()
    {

        // speed up milestones
        if (player.transform.position.x > currentMilestone)
        {
            // set the next speed up point, increase distance to the next point, increase player speed
            milestoneDistance = milestoneDistance * speedUpMultiplier;
            currentMilestone += milestoneDistance;
            playerController.MultiplySpeed(speedUpMultiplier);

            // increase the rate of score gain as well
            scoreManager.MultiplyScoreMultiplier(speedUpMultiplier);
        }
    }

    public void ResetMilestones()
    {
        currentMilestone = initialMilestoneDistance;
        milestoneDistance = initialMilestoneDistance;
    }

    private void AddNextMilestone()
    {
        Dictionary<MilestoneType, float> currentMilestone = milestoneList[milestoneIndex];
        milestoneIndex += 1;

        foreach(KeyValuePair<MilestoneType, float> milestone in currentMilestone)
        {
            ActivateMilestone(milestone.Key, milestone.Value);
        }
    }


    // TODO:
    // implement how milestone distance increases 
    // implement all milestone type changes

    private void ActivateMilestone(MilestoneType type, float magnitude)
    {
        switch (type)
        {
            case MilestoneType.SPEED_UP:
                playerController.MultiplySpeed(magnitude);
                scoreManager.MultiplyScoreMultiplier(magnitude);
                break;

            case MilestoneType.SPIKES:
                objectGenerator.SetSpikesThreshold(magnitude);
                break;

            case MilestoneType.HEIGHT_INCREASE:
                break;

            case MilestoneType.SMALLER_PLATFORM:
                break;

            case MilestoneType.ENEMIES_FALL_PLATFORM:
                break;

            default:
                break;
        }

    }
}
