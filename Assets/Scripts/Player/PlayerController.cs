using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	Animator _animator;
	public Animator playerAnimator
	{
		get
		{
			if(_animator == null)
			{
				_animator = GetComponent<Animator>();
			}

			return _animator;
		}
	}

	SpriteRenderer _spriteRenderer;
	public SpriteRenderer playerSpriteRenderer
	{
		get
		{
			if(_spriteRenderer == null)
			{
				_spriteRenderer = GetComponent<SpriteRenderer>();
			}

			return _spriteRenderer;
		}
	}

	Rigidbody2D _rigidBody;
	public Rigidbody2D playerRigidBody
	{
		get
		{
			if(_rigidBody == null)
			{
				_rigidBody = GetComponent<Rigidbody2D>();
			}

			return _rigidBody;
		}
	}
		
	void Start()
	{
		if(GetComponent<Animator>() == null)
		{
			Debug.LogError("Get Animator error");
		}
		else
		{
			_animator = GetComponent<Animator>();
		}

		if (GetComponent<SpriteRenderer>() == null)
		{
			Debug.LogError("Get spriteRenderer error");
		}
		else
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		if (GetComponent<Rigidbody2D>() == null)
		{
			Debug.LogError("Get RigidBody2D error");
		}            
		else
		{
			_rigidBody = GetComponent<Rigidbody2D>();
		}
			
	}
}
