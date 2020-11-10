using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Attributes")]
    public float playerSpeed;
    private float initialPlayerSpeed;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimer;

    private bool jumping;
    private bool canDoubleJump;


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

    private enum Color
    {
        Green,
        Blue
    }

    private Color playerCharacter = Color.Green;


	// get components attached to the object
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimer = jumpTime;
        jumping = false;
        canDoubleJump = true;

        initialPlayerSpeed = playerSpeed;
	}
	

	void Update () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float y = CheckJumpScenarios();

        // continue to move to the right
        myRigidbody.velocity = new Vector2(playerSpeed, y);

        // set variables for animator
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);

        CheckCharacterSwitch();
	}

    public void MultiplySpeed(float multiplier)
    {
        playerSpeed *= multiplier;
    }

    float CheckJumpScenarios()
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathbox")
        {
            deathSound.Play();
            gameManager.GameOver();
            playerSpeed = initialPlayerSpeed;
            powerupManager.ResetPowerups();
        }
    }

    void CheckCharacterSwitch ()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerCharacter == Color.Green)
            {
                playerCharacter = Color.Blue;
                myAnimator.runtimeAnimatorController = Resources.Load("Animators/Blue_Player") as RuntimeAnimatorController;
            }
            else
            {
                playerCharacter = Color.Green;
                myAnimator.runtimeAnimatorController = Resources.Load("Animators/Player") as RuntimeAnimatorController;
            }
        }
    }


}
