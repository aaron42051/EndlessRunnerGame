using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    private float playerSpeedStore;
    public float speedMultiplier;

    public float speedUpMilestone;
    private float speedUpMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;


    public float jumpForce;

    public float jumpTime;
    private float jumpTimer;

    private bool jumping;
    private bool canDoubleJump;


    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager gameManager;

	// get components attached to the object
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

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

        //grounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedUpMilestone;

            speedUpMilestone = speedUpMilestone * speedMultiplier;
            playerSpeed = playerSpeed * speedMultiplier;
        }

        // automatically move right, detect jumps
        float y = myRigidbody.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                y = jumpForce;
                jumping = true;
            }
            else if (canDoubleJump)
            {
                jumpTimer = jumpTime;
                jumping = true;
                y = jumpForce;
                canDoubleJump = false;
            }

        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && jumping) {

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

        myRigidbody.velocity = new Vector2(playerSpeed, y);

        // set variables for animator
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathbox")
        {
            gameManager.RestartGame();
            playerSpeed = playerSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedUpMilestone = speedUpMilestoneStore;
        }
    }
}
