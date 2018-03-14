using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Convert input into movement of Player 

public class PlayerController : MonoBehaviour 
{
	// Private variable - speed
	public float speed=50;

	// Update is called before rendering frames - most codes go here 
	// FixedUpdate is called for Physics components and calculations; this must be called after Update.

	void FixedUpdate()
	{
		// Get input from player and store, only allow horizontal movement
		float moveHorizontal = Input.GetAxis("Horizontal");

		// Change velocity (movement direction x speed)
		GetComponent<Rigidbody2D>().velocity = Vector2.right * moveHorizontal * speed;
	}
}