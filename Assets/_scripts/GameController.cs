using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	// Public variables - score system
	public Text scoreText;
	private int score;
	private int numberBlocks;

	// Public variables - level system
	public Text levelText;
	private int loadLevel;
	private int level;
	private int levelScore;

	// Public variables - lives system
	public Text livesText;
	private int lives;

	void Start ()
	{
		// Initialise and check if information stored in player preference keys

		// (1) Score Management
		// If score is stored in player preferences, obtain from key score, else set to 0. 
		score = PlayerPrefs.GetInt ("score", 0);
		UpdateScore ();

		// (2) Level Management
		// Same logic as score; set to 1 as game levels are indexed from 1.  
		loadLevel = PlayerPrefs.GetInt ("loadlevel", 1);
		// Same logic as score; set to 1 as game levels are indexed from 1.  
		level = PlayerPrefs.GetInt ("level", 1);
		UpdateLevelText ();
		levelScore = 0; // reset for each level to zero as a counter. 
		// Check how many blocks there are on the level for end level condition
		numberBlocks = GameObject.FindGameObjectsWithTag ("Block1").Length + GameObject.FindGameObjectsWithTag ("PowerUp1").Length
		+ GameObject.FindGameObjectsWithTag ("PowerUp2").Length + GameObject.FindGameObjectsWithTag ("PowerUp3").Length
		+ GameObject.FindGameObjectsWithTag ("PowerUp4").Length + GameObject.FindGameObjectsWithTag ("PowerUp5").Length
		+ GameObject.FindGameObjectsWithTag ("Block3").Length + GameObject.FindGameObjectsWithTag ("Block5").Length;
		BlockManagement ();

		// (3) Lives Management
		// Same logic as score; set to 3 for starting a new game. 
		lives = PlayerPrefs.GetInt ("lives", 3);
		livesText.text = "Lives:" + lives.ToString (); 
	}

	// External Methods
	// (1) Block Management Method
	public void BlockManagement ()
	{
		List<GameObject> blocksList = new List<GameObject> ();  
	
		// Add all game objects that are active blocks to blocksList
		foreach (GameObject blockOne in GameObject.FindGameObjectsWithTag("Block1")) {
			blocksList.Add (blockOne);
		}
		foreach (GameObject blockThree in GameObject.FindGameObjectsWithTag("Block3")) {
			blocksList.Add (blockThree);
		}
		foreach (GameObject blockFive in GameObject.FindGameObjectsWithTag("Block5")) {
			blocksList.Add (blockFive);
		}
		foreach (GameObject powerUp1 in GameObject.FindGameObjectsWithTag("PowerUp1")) {
			blocksList.Add (powerUp1);
		}
		foreach (GameObject powerUp2 in GameObject.FindGameObjectsWithTag("PowerUp2")) {
			blocksList.Add (powerUp2);
		}
		foreach (GameObject powerUp3 in GameObject.FindGameObjectsWithTag("PowerUp3")) {
			blocksList.Add (powerUp3);
		}
		foreach (GameObject powerUp4 in GameObject.FindGameObjectsWithTag("PowerUp4")) {
			blocksList.Add (powerUp4);
		}
		foreach (GameObject powerUp5 in GameObject.FindGameObjectsWithTag("PowerUp5")) {
			blocksList.Add (powerUp5);
		}
			
//		// remove blocks that have been collected
//		if (blocksList.Contains (collectedBlock.gameObject)) {
//			blocksList.Remove(collectedBlock.gameObject);
//		}

		foreach (GameObject block in blocksList) {
			print (block);
		}
	}

	// (2) Increase Score Method
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		levelScore += newScoreValue;
		UpdateScore ();
		LevelChange ();

	}

	// (3) Lives Lost Method
	public void LivesLost (int newLivesValue)
	{
		lives -= newLivesValue;
		Debug.Log ("Life lost");
		SetLives ();
	}

	// Internal methods
	// (1) Update Score Display
	void UpdateScore ()
	{
		scoreText.text = "Score:" + score; 
	}

	// (2) Update Level Info Display
	void UpdateLevelText ()
	{
		levelText.text = "Level:" + level;
	}

	// (3) Level Change Method
	// Check if all blocks have been hit, load next level
	void LevelChange ()
	{
		if (levelScore >= numberBlocks) {
			loadLevel++;
			level++;
			// Reset counter
			levelScore = 0;
			PlayerPrefs.SetInt ("level", level);
			PlayerPrefs.SetInt ("loadlevel", loadLevel);
			PlayerPrefs.SetInt ("score", score);
			PlayerPrefs.Save ();
			SceneManager.LoadScene (loadLevel);
			Debug.Log ("Load Level:" + level);
			UpdateLevelText ();
		}
	}
		
	// Set Lives Method
	public void SetLives ()
	{
		if (lives > 0) {
			PlayerPrefs.SetInt ("lives", lives);
			PlayerPrefs.Save ();
			// Respawn level
			SceneManager.LoadScene (loadLevel);
		}
		if (lives == 0) {
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.Save ();
			SceneManager.LoadScene ("GameOver");
		}
	}
}