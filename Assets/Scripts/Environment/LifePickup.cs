﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour {

	public float speed;   
	private Rigidbody2D body;
    private Vector3 target, startPosition;
    private float timeToReachTarget = 0.9f;
    private float t;
    private float elapsedTime;
    private bool canMove = false;

	// Use this for initialization
	void Start () {
		body 		  = GetComponent<Rigidbody2D>();
        startPosition = target = transform.position;
        target.y = target.y + (float)0.180;
    }

    void Update()
    {
        if(!canMove)
        {
            elapsedTime += Time.deltaTime;
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }
        if (elapsedTime > timeToReachTarget)
        {
            canMove = true;
        }
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(10f, 0);
            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            body.AddForce(movement * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Player")
		{
			Destroy (this.gameObject);
		}
        else
        {
            speed -= speed * 2;
        }
	}
}
