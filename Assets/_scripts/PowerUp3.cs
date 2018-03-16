using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PowerUp 3: Increase player paddle size
public class PowerUp3 : MonoBehaviour {

	// Define audio clips to play
	public AudioClip powerUp3Clip;

	// Define component that unity uses to play the clip
	public AudioSource audio3Source;

	// Destroy object delay
	private float sec = 0.0000005f;


	// On collision with the player activate power-up. 
	void OnCollisionEnter2D (Collision2D collect)
	{	
		if (collect.gameObject.name == "Player"){

			// Delay power up collection
			StartCoroutine ("wait");

			// Play sound when power up is collected
			audio3Source = GetComponent<AudioSource> ();
			audio3Source.clip = powerUp3Clip;
			audio3Source.PlayOneShot (audio3Source.clip);

			// Need to link the change with the object
			GameObject Player = GameObject.Find("Player");
			// Change the scale of the rendered sprite via transform properties
			Player.gameObject.transform.localScale += new Vector3(10,0,0);
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
