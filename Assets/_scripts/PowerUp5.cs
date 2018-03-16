using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerUp5 : MonoBehaviour
{
	// Define audio clips to play
	public AudioClip powerUp5Clip;

	// Define component that unity uses to play the clip
	public AudioSource audio5Source;

	// Destroy object delay
	private float sec = 0.0000005f;

	// On collision with the player activate power-up.
	void OnCollisionEnter2D (Collision2D collect)
	{	
		if (collect.gameObject.name == "Player") {

			// Delay power up collection
			StartCoroutine ("wait");

			// Play sound when power up is collected
			audio5Source = GetComponent<AudioSource> ();
			audio5Source.clip = powerUp5Clip;
			audio5Source.PlayOneShot (audio5Source.clip);

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
	IEnumerator wait ()
	{
		yield return new WaitForSeconds (sec);
		// Make power up disappear
		gameObject.SetActive (false);
	}
}