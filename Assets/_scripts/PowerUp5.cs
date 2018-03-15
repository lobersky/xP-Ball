using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerUp5 : MonoBehaviour
{
	// On collision with the player activate power-up.
	void OnCollisionEnter2D (Collision2D collect)
	{	
		if (collect.gameObject.name == "Player") {
			// Make power up disappear
			gameObject.SetActive (false);

			// Need to link the change with the object
			GameObject Ball = GameObject.Find ("Ball");

			// Define a reference to access the other script. 
			BallMovement ballMovement2 = Ball.GetComponent<BallMovement> ();

			// Using the reference, change the lives counter
			ballMovement2.lives -= 1;

			ballMovement2.livesText.text = "Lives:" + ballMovement2.lives.ToString ();
		}
	}
}