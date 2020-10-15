using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public GameObject player;
    private PlayerController playerController;

    public float speedUpMultiplier;

    public float milestoneDistance;
    private float initialMilestoneDistance;

    private float currentMilestoneDistance;

    public ScoreManager scoreManager;

    private Milestones milestones;
    private Dictionary<MilestoneType, float>[] milestoneList;
    private int milestoneIndex = 0;

    public ObjectGenerator objectGenerator;

    // Use this for initialization
    void Start () {
        currentMilestoneDistance = milestoneDistance;
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

        // if player passed a milestone point
        if (player.transform.position.x > currentMilestoneDistance)
        {
            AddNextMilestone();
        }
    }

    public void ResetMilestones()
    {
        currentMilestoneDistance = initialMilestoneDistance;
        milestoneDistance = initialMilestoneDistance;
    }

    // get milestone metadata and activate the newest milestone
    private void AddNextMilestone()
    {
        Dictionary<MilestoneType, float> currentMilestone = milestoneList[milestoneIndex];
        milestoneIndex += 1;

        foreach(KeyValuePair<MilestoneType, float> milestone in currentMilestone)
        {
            ActivateMilestone(milestone.Key, milestone.Value);
        }

        currentMilestoneDistance += milestoneDistance;
    }


    // TODO:
    // implement all milestone type changes

    private void ActivateMilestone(MilestoneType type, float magnitude)
    {
        switch (type)
        {
            case MilestoneType.SPEED_UP:
                playerController.MultiplySpeed(magnitude);
                scoreManager.MultiplyScoreMultiplier(magnitude);
                milestoneDistance *= magnitude;
                Debug.Log("speed up");
                break;

            case MilestoneType.SPIKES:
                objectGenerator.SetSpikesThreshold(magnitude);
                Debug.Log("add spikes");
                break;

            case MilestoneType.HEIGHT_INCREASE:
                objectGenerator.MultiplyHeightChange(magnitude);
                Debug.Log("height increase");
                break;

            case MilestoneType.SMALLER_PLATFORM:
                objectGenerator.AddUnlockedPlatform(1);
                Debug.Log("smaller platform");
                break;

            case MilestoneType.ENEMIES_FALL_PLATFORM:
                Debug.Log("activate platform change");
                break;

            default:
                break;
        }

    }
}
