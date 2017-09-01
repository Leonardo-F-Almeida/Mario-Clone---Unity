using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
    public float maxHeight;
    public Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public float _minValueForXPosition;
    public float _startFollowAt;
    private bool firstUpdate = true;
    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
		_minValueForXPosition = player.transform.position.x;
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		Vector3 newPosition = player.transform.position + offset;
		newPosition.y =  maxHeight;

		if (newPosition.x < _minValueForXPosition) 
		{
			newPosition.x = _minValueForXPosition;
		}
		else 
		{
			_minValueForXPosition = newPosition.x;
		}

		transform.position = newPosition;
        if(firstUpdate)
        {
            offset.x = 0;
            firstUpdate = false;
        }
    }

	public float GetCameraPositionXLimit()
	{
		return _minValueForXPosition;
	}
}
