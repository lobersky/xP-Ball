using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerUp5 : MonoBehaviour
{
	// Define variables to interact with game controller class for scoring
	public int livesLost;
	private GameController gameController;

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

			// Take off life via GameController class method
			gameController.LivesLost (livesLost);

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