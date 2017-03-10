using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLimit : MonoBehaviour {

	public float cameraOffset;
	protected CameraFollowController  _cameraFollow;

	// Use this for initialization
	void Start () {
		_cameraFollow = Camera.main.GetComponent<CameraFollowController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 newPosition = GetComponent<BoxCollider2D> ().offset;
		newPosition.x = _cameraFollow.GetCameraPositionXLimit() - cameraOffset;
		GetComponent<BoxCollider2D>().offset = newPosition;
	}
}
