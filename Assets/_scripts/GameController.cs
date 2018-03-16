using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

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
	public Text gameoverText;

	// Use this for initialization
	void Start () {

		// Initialise and check if information stored in keys for level changes
		// (1) Score 
		if (score != null) {
			score = PlayerPrefs.GetInt ("score");
		} else {
			score = 0;
		}

		// (2) Level
		if (loadLevel != null) {
			loadLevel = PlayerPrefs.GetInt ("loadlevel");
		} else {
			loadLevel = 0; // index 0 is level 1
		}

		if (level > 1) {
			level = PlayerPrefs.GetInt ("level");
		} else {
			level = 1; // start game at level 1
		}

		UpdateLevelText ();
		levelScore=0; // reset for each level to zero as a counter. 

//		// For level reload after death, do a logic check for initialisation
//		lives = PlayerPrefs.GetInt ("lives", 0);
//		if (lives == 0) {
//			lives = 3;
//		}

//		// Display lives information
//		SetLives (); 
		gameoverText.text = "";

		// Define a function to update the score displayed
		UpdateScore ();
		UpdateLevelText (); 

		// Check how many blocks there are on the level
		numberBlocks = GameObject.FindGameObjectsWithTag ("Block1").Length + GameObject.FindGameObjectsWithTag ("PowerUp1").Length
			+ GameObject.FindGameObjectsWithTag ("PowerUp2").Length + GameObject.FindGameObjectsWithTag ("PowerUp3").Length 
			+ GameObject.FindGameObjectsWithTag ("PowerUp4").Length + GameObject.FindGameObjectsWithTag ("PowerUp5").Length 
			+ GameObject.FindGameObjectsWithTag ("Block3").Length + GameObject.FindGameObjectsWithTag ("Block5").Length;
	}

	// Increase Score Method to Call in Other Scripts
	// this should only be called on colllision ... but it is using the value before collision and adding an extra value
	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		levelScore += newScoreValue;
		UpdateScore ();
		LevelChange ();
	}

//	// Lives Method to Call in Other Scripts
//	public void LivesLost (int newLivesValue){
//		lives -= newLivesValue;
//		SetLives ();
//
//	}


	// Update Score Display Function
	void UpdateScore(){
		scoreText.text = "Score:" + score; 
	}

	// Update Level Info Display Function
	void UpdateLevelText(){
		levelText.text = "Level:" + level;
	}

	// Level Change Function: 
	// Check if all blocks have been hit, load next level
	void LevelChange() {
	if (levelScore >= numberBlocks) {
		loadLevel++;
		// Reset counter
		levelScore = 0;
		PlayerPrefs.SetInt ("level", level);
		PlayerPrefs.SetInt ("loadlevel", loadLevel);
		PlayerPrefs.SetInt ("score", score);
		PlayerPrefs.Save ();
		SceneManager.LoadScene (loadLevel);
		}
	}

//	// Lives Function:
//	public void SetLives()
//	{
//		livesText.text = "Lives:" + lives.ToString ();
//
//		if (lives > 0) {
//			PlayerPrefs.SetInt ("lives", lives);
//			PlayerPrefs.Save ();
//			// Respawn level
//			SceneManager.LoadScene (loadLevel);
//		}
//		if (lives == 0) {
//			PlayerPrefs.DeleteKey ("lives");
//			PlayerPrefs.Save ();
//			livesText.text = "Game Over";
//			Destroy (GameObject.FindWithTag ("Ball"));
//		}
//	}
}