using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
		// Load game
//		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		Debug.Log ("Play button pressed");
		SceneManager.LoadScene ("Level1");
	}

	public void QuitGame(){
		Debug.Log ("Quit Game");
		Application.Quit ();
	}
}