using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	protected int _life  =  1;
	protected bool _dead;
    public AudioClip lifePicked;
    public AudioClip deathSound;

	public bool isDead
	{
		get 
		{
			return _dead;
		}
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

    AudioSource _audioSource;
    public AudioSource playerAudioSource
    {
        get
        {
            if(_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
            }

            return _audioSource;
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

    PlayerMovement _playerMovement;
    public PlayerMovement playerMovement
    {
        get
        {
            if(_playerMovement == null)
            {
                _playerMovement = GetComponent<PlayerMovement>();
            }

            return _playerMovement;
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
		
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Life")
		{
			_life += 1;
            playerAudioSource.clip = lifePicked;
            playerAudioSource.Play();
            if (playerAnimation.marioState == 0)
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
                DisableMovement();
                playerAudioSource.clip = deathSound;
                playerAudioSource.Play();
                playerAnimation.Dead();
                StartCoroutine(ReloadScene());
			}
		}
	}

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(deathSound.length);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void DisableMovement()
    {
        playerMovement.enabled = false;
    }

}
