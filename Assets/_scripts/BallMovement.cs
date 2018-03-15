using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
	// Public variables - lives system
	public Text livesText;
	public int lives = 3;

	// Public variable - game over
	public Text gameoverText;

	// Public variable - speed of the ball
	public float speedBall;

	// Start will be run on the first frame of the game.
	void Start ()
	{
		// For level reload after death, do a logic check for initialisation
		lives = PlayerPrefs.GetInt ("lives", 0);
		if (lives == 0) {
			lives = 3;
		}

		// Display lives information
		SetLivesText (); 
		gameoverText.text = "";

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

		if (col.gameObject.name == "WallBottom") {
			lives = lives - 1;
			SetLivesText ();
			if (lives > 0) {
				PlayerPrefs.SetInt ("lives", lives);
				PlayerPrefs.Save ();
				// Respawn level
				SceneManager.LoadScene ("Level1");
			}
			if (lives == 0) {
				PlayerPrefs.DeleteKey ("lives");
				PlayerPrefs.Save ();
			}
		}
	}
	// Function for lives
	public void SetLivesText ()
	{
		livesText.text = "Lives:" + lives.ToString ();
		if (lives == 0) {
			livesText.text = "Game Over";
			Destroy (GameObject.FindWithTag ("Ball"));
		}
	}
}