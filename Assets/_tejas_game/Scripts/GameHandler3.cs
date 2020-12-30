using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler3 : MonoBehaviour {

	public static GameHandler3 instance;
	public bool gameOver;
	void Awake(){
	
		if (instance == null) {
			instance = this;
		}

	}
	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		UiManager3.instance.GameStart ();
		ScoreManager2.instance.startScore ();
		GameObject.Find ("PlatformSpawnner").GetComponent<PlatformSpawnner>().StartSpawningPlatforms ();

	}


	public void GameOver(){
		UiManager3.instance.GameOver ();
		ScoreManager2.instance.stopScore ();
		gameOver = true;


	}
}
