using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHead : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerMovement>().EnemyBounce();
            this.GetComponentInParent<Goomba>().Hit();
            Destroy(gameObject);
        }
    }
}
