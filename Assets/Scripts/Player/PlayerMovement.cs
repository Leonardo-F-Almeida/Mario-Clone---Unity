using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController {


    public float speed;             //Floating point variable to store the player's movement speed.
    
	 //FixedUpdate is called at a fixed interval and is independent of frame rate.
    void FixedUpdate()
    {
		Move ();
		Jump ();
    }

	void Move()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		if(moveHorizontal != 0)
		{
			playerAnimation.RunningAnimation (true);	
		}
		else
		{
			playerAnimation.RunningAnimation (false);
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
	}

	void Jump()
	{
		if(Input.GetKeyDown("space"))
		{
			if(isGrounded)
			{
				playerAnimation.Jump (true);

				Vector2 jumpVector = new Vector2 (0, 200);

				playerRigidBody.AddForce (jumpVector);  

				isGrounded = false;
			}
		}	
	}
		
}
