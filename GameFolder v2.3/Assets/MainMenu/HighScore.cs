using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HighScore : MonoBehaviour {
	
	public Text highScoreText;
	
	// Use this for initialization
	void Start () {
		highScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
