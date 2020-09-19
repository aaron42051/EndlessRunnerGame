using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerController player;
    private Vector3 playerPosition;
    private float distanceToMove;

	void Start () {

        // get the player object
        player = FindObjectOfType<PlayerController>();
        playerPosition = player.transform.position;

	}
	
    // follow the player
	void Update () {

        distanceToMove = player.transform.position.x - playerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        playerPosition = player.transform.position;
	}
}
