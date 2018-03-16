﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
	// Define variables to interact with game controller class for scoring
	public int livesLost;
	private GameController gameController;

	// Public variable - speed of the ball
	public float speedBall;

	// Start will be run on the first frame of the game.
	void Start ()
	{
		// Set initial velocity of the ball
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speedBall;
	}

	float hitFactor (Vector2 ballPos, Vector2 objPos,
	                 float objHeight)
	{
		return (ballPos.y - objPos.y) / objHeight;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Player") {
			float y = hitFactor (transform.position,
				          col.transform.position,
				          col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (y, 1).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speedBall;
		}

//		if (col.gameObject.name == "WallBottom") {
//			gameController.LivesLost (livesLost);
//			}
	}
}