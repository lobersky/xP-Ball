using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PowerUp 4: Decrease player paddle size
public class PowerUp4 : MonoBehaviour {

	// Define audio clips to play
	public AudioClip powerUp4Clip;

	// Define component that unity uses to play the clip
	public AudioSource audio4Source;

	// Destroy object delay
	private float sec = 0.0000005f;

	// On collision with the player activate power-up. 
	void OnCollisionEnter2D (Collision2D collect)
	{	
		if (collect.gameObject.name == "Player"){

			// Delay power up collection
			StartCoroutine ("wait");

			// Play sound when power up is collected
			audio4Source = GetComponent<AudioSource> ();
			audio4Source.clip = powerUp4Clip;
			audio4Source.PlayOneShot (audio4Source.clip);

			// Need to link the change with the object
			GameObject Player = GameObject.Find("Player");
			// Change the scale of the rendered sprite via transform properties
			Player.gameObject.transform.localScale -= new Vector3(10,0,0);
			// Make power up disappear
			gameObject.SetActive(false);
		}
	}

	IEnumerator wait ()
	{
		yield return new WaitForSeconds (sec);
		// Make power up disappear
		gameObject.SetActive (false);
	}
}