using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Attributes")]
    public float playerSpeed;
    private float playerSpeedStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimer;

    private bool jumping;
    private bool canDoubleJump;

    [Header("Difficulty Progression")]
    public float speedUpMultiplier;

    public float speedUpMilestone;
    private float speedUpMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;




    private Rigidbody2D myRigidbody;

    [Header("Grounded Check")]
    public bool grounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;


    private Animator myAnimator;

    [Header("Player Sound Effects")]
    public AudioSource jumpSound;
    public AudioSource deathSound;

    [Header("Managers")]
    public GameManager gameManager;
    public PowerupManager powerupManager;


	// get components attached to the object
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimer = jumpTime;
        jumping = false;
        canDoubleJump = true;

        speedMilestoneCount = speedUpMilestone;

        playerSpeedStore = playerSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedUpMilestoneStore = speedUpMilestone;
	}
	

	void Update () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // add to the game every milestone
        checkMilestone();

        float y = checkJumpScenarios();

        // continue to move to the right
        myRigidbody.velocity = new Vector2(playerSpeed, y);

        // set variables for animator
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}

    void checkMilestone()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedUpMilestone;
            speedUpMilestone = speedUpMilestone * speedUpMultiplier;
            playerSpeed = playerSpeed * speedUpMultiplier;
        }
    }

    float checkJumpScenarios()
    {
        float y = myRigidbody.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // jumping
            if (grounded)
            {
                jumpSound.Play();
                y = jumpForce;
                jumping = true;
            }
            // double jumping
            else if (canDoubleJump)
            {
                jumpSound.Play();
                jumpTimer = jumpTime;
                jumping = true;
                y = jumpForce;
                canDoubleJump = false;
            }

        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && jumping)
        {

            if (jumpTimer > 0)
            {
                y = jumpForce;
                jumpTimer -= Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimer = 0;
            jumping = false;
        }

        if (grounded)
        {
            jumpTimer = jumpTime;
            canDoubleJump = true;
        }

        return y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathbox")
        {
            deathSound.Play();
            gameManager.GameOver();
            playerSpeed = playerSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedUpMilestone = speedUpMilestoneStore;
            powerupManager.ResetPowerups();
        }
    }
}
