using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : PhysicsObject {

    public float maxSpeed = 2;
    protected Vector2 moveDirection = Vector2.right;
    protected bool _startMove = false;
    override protected void ComputeVelocity()
    {
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
        if (coll.gameObject.tag == "Player")
        {
            //Destroy(this.gameObject);
        }
        else
        {
            moveDirection -= moveDirection * 2;
        }
    }
}
