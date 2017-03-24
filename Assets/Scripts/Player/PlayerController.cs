using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	protected int _life  =  1;
	protected bool _grounded;
	protected bool _dead;


	public bool isDead
	{
		get 
		{
			return _dead;
		}
	}

	public bool isGrounded
	{
		get { return _grounded; }
		set { _grounded = value; }
	}

	public int life
	{
		get 
		{
			return _life;
		}
	}

	public void AddLife(int qtd) 
	{
		this._life += qtd;	
	}


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

	PlayerAnimationController _playerAnimationController;

	public PlayerAnimationController playerAnimation
	{
		get
		{
			if(_playerAnimationController == null)
			{
				_playerAnimationController = GetComponent<PlayerAnimationController>();
			}

			return _playerAnimationController;
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

		if (GetComponent<PlayerAnimationController>() == null)
		{
			Debug.LogError("Get PlayerAnimationsController error");
		}            
		else
		{
			_playerAnimationController = GetComponent<PlayerAnimationController>();
		}
			
	}


	void FixedUpdate()
	{
		isGrounded = true;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		
		if (coll.gameObject.tag == "ground" || coll.gameObject.tag == "Block")
		{
			isGrounded = true;
		}

		if (coll.gameObject.tag == "Life")
		{
			_life += 1;

			if(playerAnimation.marioState == 0)
			{
				playerAnimation.GrowMario();
			}
		}

		if (coll.gameObject.tag == "Enemy")
		{
			_life -= 1;

			if(playerAnimation.marioState == 1)
			{
				playerAnimation.DecreaseMario();
			}

			if (_life <= 0) 
			{
				_dead = true;
			}
		}
	}

}
