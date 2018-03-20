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

		// (3) Lives Management
		// Same logic as score; set to 3 for starting a new game. 
		lives = PlayerPrefs.GetInt ("lives", 3);
		livesText.text = "Lives:" + lives.ToString (); 

//		 Option 2 - Find each block by name - seems super tedious! 
		List<GameObject> blocksList = new List<GameObject>();
		// want a list of all game objects that are blocks
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

		foreach (GameObject block in blocksList) {
			print (block);
		}

		// BLOCK DATABASE REFERENCE AND MANAGEMENT 
		// Options 1 - Define a function to do this: https://answers.unity.com/questions/179310/how-to-find-all-objects-in-specific-layer.html
		// where the layer is 1 - Middle Ground as there are only blocks on this layer. 
		//		function FindGameObjectsWithLayer (layer : int) : GameObject[] {
		//			var goArray = FindObjectsOfType(GameObject);
		//			var goList = new System.Collections.Generic.List.<GameObject>();
		//			for (var i = 0; i < goArray.Length; i++) {
		//				if (goArray[i].layer == layer) {
		//					goList.Add(goArray[i]);
		//				}
		//			}
		//			if (goList.Count == 0) {
		//				return null;
		//			}
		//			return goList.ToArray();
		//		}
		// Option 2 - Find each block by name - seems super tedious! 
		//		List<GameObject> blocksList = new List<GameObject>();
		//		// want a list of all game objects that are blocks
		//		GameObject blockOne =  GameObject.Find("Block1 (2)");
		//		blocksList.Add(blockOne);
		//		print (blocksList [0]);
		//		// is it possible to find by prefab and organise each instance of a prefab as a separate object? ... maybe
	}

//	// Test Methods
//	public void FindGameObjectsWithLayer (int layer, GameObject block){
//		var goArray = FindObjectOfType (GameObject);
//		var goList = new System.Collections.Generic.List<GameObject>();
//		for (var i = 0; i < goArray.Length; i++){
//			if (goArray [i].layer == layer) {
//				goList.Add (goArray [i]);
//			}
//			if (goList.Count == 0) {
//				return null;
//			}
//			return goList.ToArray ();	
//		}
//	}

	// Methods
	// (1) Increase Score Method to Call in Other Scripts
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		levelScore += newScoreValue;
		UpdateScore ();
		LevelChange ();
	}

	// (2) Lives Method to Call in Other Scripts
	public void LivesLost (int newLivesValue)
	{
		lives -= newLivesValue;
		SetLives ();
	}


	// Update Score Display Function
	void UpdateScore ()
	{
		scoreText.text = "Score:" + score; 
	}

	// Update Level Info Display Function
	void UpdateLevelText ()
	{
		levelText.text = "Level:" + level;
	}

	// Level Change Function:
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

	//	SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	//	Debug.Log ("Load Level 1");

	// Lives Function:
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