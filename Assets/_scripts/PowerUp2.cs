using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
{
	// Define audio clips to play
	public AudioClip powerUp2Clip;

	// Define component that unity uses to play the clip
	public AudioSource audio2Source;

	// Destroy object delay
	private float sec = 0.0000005f;


	void OnCollisionEnter2D (Collision2D collect)
	{	
		// PowerUp 2: Decrease ball speed
		if (collect.gameObject.name == "Player") {

			// Delay power up collection
			StartCoroutine ("wait");

			// Play sound when power up is collected
			audio2Source = GetComponent<AudioSource> ();
			audio2Source.clip = powerUp2Clip;
			audio2Source.PlayOneShot (audio2Source.clip);

			// Need to link the change with the object
			GameObject Ball = GameObject.Find ("Ball");
			// Define a reference to access the other script. 
			BallMovement ballMovement = Ball.GetComponent<BallMovement> ();
			// Increase the speed of the ball 
			ballMovement.speedBall = ballMovement.speedBall - 2;
			// Make power up disappear
			gameObject.SetActive (false);
		}
		if (collect.gameObject.name == "WallBottom") {
			// Make power up disappear
			gameObject.SetActive (false);
		}
	}

	IEnumerator wait ()
	{
		yield return new WaitForSeconds (sec);
		// Make power up disappear
		gameObject.SetActive (false);
	}
}