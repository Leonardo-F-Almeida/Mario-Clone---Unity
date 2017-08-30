using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController {


    public float speed;             //Floating point variable to store the player's movement speed.
    public AudioClip jumpSoundClip;

    void FixedUpdate()
    {
		Move ();
		Jump ();
    }


	void Move()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		if (playerRigidBody.velocity.y == 0) 
		{
			if (isGrounded != true) 
			{
				isGrounded = true;
				playerAnimation.Jump (false);	
			}
		}
		else 
		{
			isGrounded = false;
		}

		if(moveHorizontal == 0)
		{
			playerAnimation.RunningAnimation (false);	
		}
		else
		{
			playerAnimation.RunningAnimation (true);
		}


		if(moveHorizontal < 0)
		{
			playerSpriteRenderer.flipX = true;
		}

		if(moveHorizontal > 0)
		{
			playerSpriteRenderer.flipX = false;	
		}

		Vector2 movement = new Vector2 (moveHorizontal, 0);

		playerRigidBody.AddForce (movement * speed);

		if (moveHorizontal > 0  && isGrounded && Input.GetKeyDown(KeyCode.LeftArrow)||moveHorizontal < 0 && isGrounded && Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			playerAnimation.Drift ();
		}
	}

	void Jump()
	{
		if(Input.GetKeyDown("space"))
		{
			if(isGrounded)
			{
				playerAnimation.Jump (true);

				Vector2 jumpVector = new Vector2 (0, 200);
                PlayJumpSound();
				playerRigidBody.AddForce (jumpVector);  
			}
		}	
	}

    void PlayJumpSound()
    {
        playerAudioSource.clip = jumpSoundClip;
        playerAudioSource.Play();
    }
		
}
