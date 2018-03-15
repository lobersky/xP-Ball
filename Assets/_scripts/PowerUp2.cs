using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D collect)
	{	
		// PowerUp 2: Decrease ball speed
		if (collect.gameObject.name == "Player") {
			// Need to link the change with the object
			GameObject Ball = GameObject.Find ("Ball");
			// Define a reference to access the other script. 
			BallMovement ballMovement = Ball.GetComponent<BallMovement> ();
			// Increase the speed of the ball 
			ballMovement.speedBall = ballMovement.speedBall - 2;
			// Make power up disappear
			gameObject.SetActive (false);
		}
	}
}