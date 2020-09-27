using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    private ObjectPooler[] objectPoolers;

    public ScoreManager scoreManager;

    public PowerupManager powerupManager;

    public DifficultyManager difficultyManager;

    public DeathMenu deathMenu;

    public bool powerupReset;

	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
	}

    // stop tracking score, remove player, show death screen
    public void GameOver()
    {
        scoreManager.SetAlive(false);
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
        //difficultyManager.resetMilestones();
    }

    // reset the game environment to start a new game
    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);

        ClearAllObjects();

        // reset player position
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.ResetScore();

        powerupReset = true;
    }

    private void ClearAllObjects()
    {
        // get all object poolers and remove everything out of them
        objectPoolers = FindObjectsOfType<ObjectPooler>();
        for (int i = 0; i < objectPoolers.Length; i++)
        {
            objectPoolers[i].DeactivateAllObjects();
        }

    }

}
