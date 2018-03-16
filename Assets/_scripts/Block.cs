using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
	// Define variables to interact with game controller class for scoring
	public int scoreValue;
	private GameController gameController;

	// Multi-hit blocks: hit damage counter and sprites to access
	private int hitBlock;
	private SpriteRenderer spriteRenderer;
	public Sprite Block1;
	public Sprite Block3;

	// Power-ups: define prefabs to instatiate on collision
	public GameObject prefabPowerUp1;
	public GameObject prefabPowerUp2;
	public GameObject prefabPowerUp3;
	public GameObject prefabPowerUp4;
	public GameObject prefabPowerUp5;

	// Use this for initialization
	void Start ()
	{
		// Need to reference a specific instance of the Game Controller Class to do scoring
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script, is object reference attached correctly?");
		}
			
		// Initilise hit counter for blocks
		hitBlock = 0; 
	}

	void OnCollisionEnter2D (Collision2D hit)
	{
		//Check if a power-up block has been hit
		if (gameObject.tag == "PowerUp1") {
			// Generate power up
			Instantiate (prefabPowerUp1, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			gameController.AddScore(scoreValue);
		}

		if (gameObject.tag == "PowerUp2") {
			// Generate power up
			Instantiate (prefabPowerUp2, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			gameController.AddScore(scoreValue);
		}

		if (gameObject.tag == "PowerUp3") {
			// Generate power up
			Instantiate (prefabPowerUp3, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			gameController.AddScore(scoreValue);
		}

		if (gameObject.tag == "PowerUp4") {
			// Generate power up
			Instantiate (prefabPowerUp4, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			gameController.AddScore(scoreValue);
		}

		if (gameObject.tag == "PowerUp5") {
			// Generate power up
			Instantiate (prefabPowerUp5, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			gameController.AddScore(scoreValue);
		}

		// For regular blocks, check type and damage required.

		if (gameObject.tag == "Block1") {
			// One hit destroy object, deactivate block on collision with ball 
			gameObject.SetActive (false);
			gameController.AddScore(scoreValue);
		}

		if (gameObject.tag == "Block3") {
			spriteRenderer = GetComponent<SpriteRenderer> ();
			// Multi-hit x 2 to destroy object, each hit instance change sprite. 
			hitBlock++;

			if (hitBlock >= 1) {
				spriteRenderer.sprite = Block1;
				gameObject.tag = "Block1";
			}
		}

		if (gameObject.tag == "Block5") {
			spriteRenderer = GetComponent<SpriteRenderer> ();
			// Multi-hit x 3 to destroy object, each hit instance change sprite. 
			hitBlock++;

			if (hitBlock == 1) {
				spriteRenderer.sprite = Block3;
				gameObject.tag = "Block3";
			}
		}
	}
}