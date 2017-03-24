using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadHit : MonoBehaviour {

	public PlayerController playerController;
	private int _startLife;

	void Start()
	{
		_startLife = playerController.life;
	}

	void Update()
	{
		ChangeHeadCollider ();
	}

	void ChangeHeadCollider()
	{
		
		if(_startLife != playerController.life)
		{
			_startLife = playerController.life;

			Vector2 newColliderPosition = GetComponent<BoxCollider2D> ().offset;

			if (playerController.life == 1) 
			{	
				newColliderPosition.y -= 0.07f;
			}

			if (playerController.life == 2) 
			{
				newColliderPosition.y += 0.07f;
			}	

			GetComponent<BoxCollider2D> ().offset = newColliderPosition;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Block") 
		{
			coll.gameObject.GetComponent<Block> ().OnHit ();
		}
	}
}
