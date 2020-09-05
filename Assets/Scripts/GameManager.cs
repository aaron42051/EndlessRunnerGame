using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    private ObjectPooler[] objectPoolers;

    private ScoreManager scoreManager;

    public DeathMenu deathMenu;

    public bool powerupReset;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        scoreManager.isAlive = false;
        player.gameObject.SetActive(false);


        deathMenu.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);

        objectPoolers = FindObjectsOfType<ObjectPooler>();
        for (int i = 0; i < objectPoolers.Length; i++)
        {
            objectPoolers[i].DeactivateAllPlatforms();
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.isAlive = true;

        powerupReset = true;
    }

    //public IEnumerator RestartGameCo()
    //{
    //    scoreManager.isAlive = false;
    //    player.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.5f);

    //    objectPoolers = FindObjectsOfType<ObjectPooler>();
    //    for (int i = 0; i < objectPoolers.Length; i++)
    //    {
    //        objectPoolers[i].DeactivateAllPlatforms();
    //    }

    //    player.transform.position = playerStartPoint;
    //    platformGenerator.position = platformStartPoint;
    //    player.gameObject.SetActive(true);

    //    scoreManager.scoreCount = 0;
    //    scoreManager.isAlive = true;
    //}
}
