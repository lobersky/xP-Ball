using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PowerUp 3: Increase player paddle size
public class PowerUp3 : MonoBehaviour {

	// On collision with the player activate power-up. 
	void OnCollisionEnter2D (Collision2D collect)
	{	
		if (collect.gameObject.name == "Player"){
			// Need to link the change with the object
			GameObject Player = GameObject.Find("Player");
			// Change the scale of the rendered sprite via transform properties
			Player.gameObject.transform.localScale += new Vector3(10,0,0);
			// Make power up disappear
			gameObject.SetActive(false);
		}
	}
}
