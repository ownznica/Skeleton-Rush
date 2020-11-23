using System.Collections;
using UnityEngine.UI; 
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {
	
	public Text playerScoreText;
	
	// Use this for initialization
	void Start () {
		playerScoreText.text = PlayerPrefs.GetInt("PlayerEndScore").ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
