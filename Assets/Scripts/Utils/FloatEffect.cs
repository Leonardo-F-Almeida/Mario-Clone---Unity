using UnityEngine;
using System.Collections;

public class FloatEffect : MonoBehaviour 
{
	private float startFloatingPosition;
	public float movementAmplitude;
	public float speed;
//--------------------------------------------------------------
	void Start () 
	{
		startFloatingPosition = transform.position.y;
	}
//--------------------------------------------------------------	
	void Update () 
	{
		Vector2 newPosition 	= transform.position;
		newPosition.y 			= 	startFloatingPosition + movementAmplitude * Mathf.Sin(speed * Time.time);
		transform.position 		= newPosition;
	}
//--------------------------------------------------------------
}
