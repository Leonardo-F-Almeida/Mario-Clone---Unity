using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : PhysicsObject {

    public float maxSpeed = 2;
    public LayerMask backgroundLayer;
    protected Vector2 moveDirection = Vector2.right;
    protected bool _startMove = false;
    protected bool isHit = false;

    override protected void ComputeVelocity()
    {
        if (isHit) return;

        if(gameObject.GetComponent<Renderer>().isVisible)
        {
            _startMove = true;
        }

        if(_startMove)
        {
            Vector2 move = moveDirection;
            targetVelocity = move * maxSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && !isHit)
        {
            coll.gameObject.GetComponent<PlayerController>().EnemyCollision();
        }
        else
        {
            moveDirection -= moveDirection * 2;
        }
    }

    public void Hit()
    {
        isHit = true;
        GetComponent<Animator>().SetBool("stepped", true);
        // make sure collision are off between the playerLayer and the enemyLayer
        int backgroundLayer = LayerMask.NameToLayer("background");
        gameObject.layer = backgroundLayer;
        Destroy(gameObject, 1f);
    }

}
