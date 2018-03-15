using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{

	// Public variables - score system
	public Text scoreText;
	public static int score = 0;
	private static int levelScore=0; 

	// Public variables - level system
	public static int level = 0;

	// Public variable - level complete
	public Text levelText;

	// Private variable - block counters
	private static int numberBlocks;

	// Private variable - damage counter
	private int hitBlock;

	// Sprite Manager variables
	private SpriteRenderer spriteRenderer;
	public Sprite Block1;
	public Sprite Block3;

	// Power-up prefab variables
	public GameObject prefabPowerUp1;
	public GameObject prefabPowerUp2;
	public GameObject prefabPowerUp3;
	public GameObject prefabPowerUp4;
	public GameObject prefabPowerUp5;

	// Use this for initialization
	void Start ()
	{
		// Intialise score for current level
		levelScore=0;

		// For level reload after death, do a logic check for initialisation of overall score
		score = PlayerPrefs.GetInt ("score", score);
		if (score == 0) {
			score = 0;
		}

		// Initilise hit counter for blocks
		hitBlock = 0; 

		// Display score bar
		SetScoreText ();

		// Initialise end of level text
		levelText.text = "";

		// Check how many blocks there are
		numberBlocks = GameObject.FindGameObjectsWithTag ("Block1").Length + GameObject.FindGameObjectsWithTag ("Block2").Length + GameObject.FindGameObjectsWithTag ("Block3").Length + GameObject.FindGameObjectsWithTag ("Block5").Length;
	}

	void OnCollisionEnter2D (Collision2D hit)
	{
		//Check if a power-up block has been hit
		if (gameObject.tag == "PowerUp1") {
			// Generate power up
			Instantiate (prefabPowerUp1, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			score++;
			levelScore++;
			SetScoreText ();
		}

		if (gameObject.tag == "PowerUp2") {
			// Generate power up
			Instantiate (prefabPowerUp2, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			score++;
			levelScore++;
			SetScoreText ();
		}

		if (gameObject.tag == "PowerUp3") {
			// Generate power up
			Instantiate (prefabPowerUp3, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			score++;
			levelScore++;
			SetScoreText ();
		}

		if (gameObject.tag == "PowerUp4") {
			// Generate power up
			Instantiate (prefabPowerUp4, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			score++;
			levelScore++;
			SetScoreText ();
		}

		if (gameObject.tag == "PowerUp5") {
			// Generate power up
			Instantiate (prefabPowerUp5, new Vector2 (hit.transform.position.x, hit.transform.position.y), Quaternion.identity);
			// Destroy block
			gameObject.SetActive (false);
			score++;
			levelScore++;
			SetScoreText ();
		}

		// For regular blocks, check type and damage required.

		if (gameObject.tag == "Block1") {
			// One hit destroy object, deactivate block on collision with ball 
			gameObject.SetActive (false);
			score++; 
			levelScore++;
			SetScoreText ();
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

		// Check if all blocks have been hit, load next level
		if (levelScore >= numberBlocks) {
			level++;
			// Reset counter
			levelScore = 0;
			SceneManager.LoadScene (level);
		}
	}
	// Function for the score bar
	void SetScoreText ()
	{
		scoreText.text = "Score:" + score.ToString ();
		PlayerPrefs.SetInt ("Score", score);
		PlayerPrefs.Save ();
		if (levelScore >= numberBlocks) {
			levelText.text = "Level Complete!";
		}
	}
}