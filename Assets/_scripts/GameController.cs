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

	void Start () {
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
		levelScore=0; // reset for each level to zero as a counter. 
		// Check how many blocks there are on the level for end level condition
		numberBlocks = GameObject.FindGameObjectsWithTag ("Block1").Length + GameObject.FindGameObjectsWithTag ("PowerUp1").Length
			+ GameObject.FindGameObjectsWithTag ("PowerUp2").Length + GameObject.FindGameObjectsWithTag ("PowerUp3").Length 
			+ GameObject.FindGameObjectsWithTag ("PowerUp4").Length + GameObject.FindGameObjectsWithTag ("PowerUp5").Length 
			+ GameObject.FindGameObjectsWithTag ("Block3").Length + GameObject.FindGameObjectsWithTag ("Block5").Length;
		
		// (3) Lives Management
		// Same logic as score; set to 3 for starting a new game. 
		lives = PlayerPrefs.GetInt ("lives", 3);
		livesText.text = "Lives:" + lives.ToString (); 
		gameoverText.text = "";
	}

	// Methods
	// (1) Increase Score Method to Call in Other Scripts
		public void AddScore (int newScoreValue) {
		score += newScoreValue;
		levelScore += newScoreValue;
		UpdateScore ();
		LevelChange ();
	}

	// (2) Lives Method to Call in Other Scripts
	public void LivesLost (int newLivesValue){
		lives -= newLivesValue;
		SetLives ();
	}


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

//	SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
//	Debug.Log ("Load Level 1");

	// Lives Function:
	public void SetLives()
	{
		if (lives > 0) {
			PlayerPrefs.SetInt ("lives", lives);
			PlayerPrefs.Save ();
			// Respawn level
			SceneManager.LoadScene (loadLevel);
		}
		if (lives == 0) {
			PlayerPrefs.DeleteAll();
			PlayerPrefs.Save ();
			livesText.text = "Game Over";
			Destroy (GameObject.FindWithTag ("Ball"));
		}
	}
}