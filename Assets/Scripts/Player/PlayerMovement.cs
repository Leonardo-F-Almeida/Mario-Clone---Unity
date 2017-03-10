using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController {


    public float speed;             //Floating point variable to store the player's movement speed.
    private bool isGrounded;
    
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
			playerAnimator.SetBool("isRunning",true);	
		}
		else
		{
			playerAnimator.SetBool("isRunning",false	);		
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
				playerAnimator.SetBool("isJump",true);

				Vector2 jumpVector = new Vector2 (0, 200);

				playerRigidBody.AddForce (jumpVector);  

				isGrounded = false;
			}
		}	
	}



     void OnCollisionEnter2D(Collision2D coll) 
     {
        if (coll.gameObject.tag == "ground")
        {
            isGrounded = true;
			playerAnimator.SetBool("isJump",false);
        }
        if (coll.gameObject.tag == "Enemy")
        {
                isGrounded = true;
			playerAnimator.SetBool("isJump",false);
        }
    }
}
