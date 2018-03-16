using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
	// Define audio clips to play
	public AudioClip powerUp1Clip;

	// Define component that unity uses to play the clip
	public AudioSource audio1Source;

	// Destroy object delay
	private float sec = 0.0000005f;

	void OnCollisionEnter2D (Collision2D collect)
	{
		// PowerUp 1: Increase ball speed
		if (collect.gameObject.name == "Player") {

			// Delay power up collection
			StartCoroutine ("wait");

			// Play sound when power up is collected
			audio1Source = GetComponent<AudioSource> ();
			audio1Source.clip = powerUp1Clip;
			audio1Source.PlayOneShot (audio1Source.clip);

			// Need to link the change with the object
			GameObject Ball = GameObject.Find ("Ball");
			// Define a reference to access the other script. 
			BallMovement ballMovement = Ball.GetComponent<BallMovement> ();
			// Increase the speed of the ball 
			ballMovement.speedBall = ballMovement.speedBall + 4;
		}
	}

	IEnumerator wait ()
	{
		yield return new WaitForSeconds (sec);
		// Make power up disappear
		gameObject.SetActive (false);
	}
}