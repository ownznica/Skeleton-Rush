﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void ReplayGame(){
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
		
	}
	
	public void QuitGame(){
		Debug.Log("QUIT!");
		Application.Quit();
	}
	
}
