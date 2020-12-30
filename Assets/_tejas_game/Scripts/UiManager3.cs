using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager3 : MonoBehaviour {
	
	public static UiManager3 instance;

	public GameObject zizagPanel;
	public GameObject gameOverPanel,gameplay;
	public GameObject tapText;

	public Text score,gameplay_score;
	public Text highScore1;
	public Text highScore2;


	void Awake(){
		if (instance == null) {
			instance = this;
		}

	}
	// Use this for initialization
	void Start () {
		gameplay.SetActive (false);
		highScore1.text="High Score: " + PlayerPrefs.GetInt("highScore");
		
	}

	void Update(){
		gameplay_score.text = ScoreManager2.instance.score.ToString ();
	}

	public void showleader(){
		FindObjectOfType<playservices> ().zz_showlead ();
	}

	public void GameStart(){
		tapText.SetActive (false);
		zizagPanel.GetComponent<Animator> ().Play ("panelUp");
		gameplay.SetActive (true);
	}

	public void GameOver(){
		gameplay.SetActive (false);
		score.text = PlayerPrefs.GetInt ("score").ToString();
		highScore2.text=PlayerPrefs.GetInt("highScore").ToString();
		gameOverPanel.SetActive (true);
		
	}

	public void Reset(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}
}
