using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed;             //Floating point variable to store the player's movement speed.
    Animator animator;
    SpriteRenderer sprite;
    private Rigidbody2D body;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private bool isGrounded;
    
	// Use this for initialization
	void Start () {
		body 		= GetComponent<Rigidbody2D>();
		animator 	= GetComponent<Animator>();
		sprite 		= GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current vertical input in the float moveVertical.
        float moveHorizontal = Input.GetAxis ("Horizontal");
        
        if(Input.GetKeyDown("space"))
        {
            if(isGrounded)
            {
                animator.SetBool("isJump",true);
                
                Vector2 jumpVector = new Vector2 (0, 200);

                body.AddForce (jumpVector);  

                isGrounded = false;
            }
        	
        }	

        if(moveHorizontal != 0)
        {
        	animator.SetBool("isRunning",true);	
        }
        else
        {
        	animator.SetBool("isRunning",false	);		
        }
        

        if(moveHorizontal < 0)
        {
        	sprite.flipX = true;
        }
        
		if(moveHorizontal > 0)
        {
        	sprite.flipX = false;	
        }

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        body.AddForce (movement * speed);
    }

     void OnCollisionEnter2D(Collision2D coll) 
     {
        if (coll.gameObject.tag == "ground")
        {
                isGrounded = true;
                animator.SetBool("isJump",false);
        }
        if (coll.gameObject.tag == "Enemy")
        {
                isGrounded = true;
                animator.SetBool("isJump",false);
        }
    }
}
