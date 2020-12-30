﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager2 : MonoBehaviour {

	public static ScoreManager2 instance;

	public int score;
	public int highScore;

	void Awake(){
	    
		if (instance == null) {
		    instance = this;
		}

	}
	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("score", score);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementScore(int x){
			score += x;
	}

	public void startScore(){
		//InvokeRepeating ("IncrementScore", 0.1f, 0.5f);
	}

	public void stopScore(){
		
		//CancelInvoke ("IncrementScore");

		PlayerPrefs.SetInt ("score", score);

		playservices.instance.zz_addscore (score);

		if (PlayerPrefs.HasKey ("highScore")) {
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score);
			}
		
		} else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}
}
