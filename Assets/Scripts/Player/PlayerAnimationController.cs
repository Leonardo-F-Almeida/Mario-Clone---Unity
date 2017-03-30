using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : PlayerController 
{
	//0 small - 1 big
	protected int _marioState = 0;

	public int marioState 
	{
		get
		{
			return _marioState;
		}
	}

	public void DecreaseMario()
	{
		playerAnimator.SetLayerWeight (0, 1);
		playerAnimator.SetLayerWeight (1, 1);
		Vector2 newBoxColliderSize = GetComponent<BoxCollider2D> ().size;
		newBoxColliderSize.y -= 0.13f;
		GetComponent<BoxCollider2D> ().size = newBoxColliderSize;
		_marioState = 0;
	}

	public void GrowMario()
	{
		playerAnimator.SetLayerWeight (0, 1);
		playerAnimator.SetLayerWeight (1, 0);
		Vector2 newBoxColliderSize = GetComponent<BoxCollider2D> ().size;
		newBoxColliderSize.y += 0.13f;
		GetComponent<BoxCollider2D> ().size = newBoxColliderSize;	
		_marioState = 1;
	}
		

	public void RunningAnimation(bool isRunning)
	{
		playerAnimator.SetBool("isRunning",isRunning);
	}

	public void Jump(bool isJump)
	{
		playerAnimator.SetBool("isJump",isJump);
	}

	public void Drift()
	{
		playerAnimator.SetTrigger ("drift");
	}
}
