using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PhysicsObject
{
    public float maxSpeed = 2;
    public float jumpTakeOffSpeed = 3;
    public AudioClip jumpSoundClip;
    SpriteRenderer _spriteRenderer;
    public SpriteRenderer playerSpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }

            return _spriteRenderer;
        }
    }

    AudioSource _audioSource;
    public AudioSource playerAudioSource
    {
        get
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
            }

            return _audioSource;
        }
    }
    PlayerAnimationController _playerAnimation;
    public PlayerAnimationController playerAnimationController
    {
        get
        {
            if (_playerAnimation == null)
            {
                _playerAnimation = GetComponent<PlayerAnimationController>();
            }

            return _playerAnimation;
        }
    }
    
    protected override void ComputeVelocity()
    {
        playerAnimationController.RunningAnimation(false);

        if(grounded)
        {
            playerAnimationController.Jump(false);
        }
        
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            PlayJumpSound();
            playerAnimationController.Jump(true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (move.x > 0.001f && move.x != 0)
        {
            playerSpriteRenderer.flipX = false;
            playerAnimationController.RunningAnimation(true);
        }

        if (move.x < 0.001f && move.x != 0)
        {
            playerSpriteRenderer.flipX = true;
            playerAnimationController.RunningAnimation(true);
        }
        
        targetVelocity = move * maxSpeed;
    }


    void PlayJumpSound()
    {
        playerAudioSource.clip = jumpSoundClip;
        playerAudioSource.Play();
    }


}
