﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
		// Load game
		Debug.Log ("Play button pressed");
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		Debug.Log ("Player preferences reset");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Debug.Log ("Load Level 1");
	}

	public void QuitGame(){
		Debug.Log ("Quit Game");
		Application.Quit ();
	}
}