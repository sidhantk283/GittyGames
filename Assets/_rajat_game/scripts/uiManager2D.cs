using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager2D : MonoBehaviour {
	[Header("GamePlay")]
	public Text ScoreText;
	public Text miss_display;
	public static int score_chromatic;
	public int miss;
	[Space(5)]



	[Range(0,10)]
	public int miss_text;
	[Space(5)]


	public bool gameOver_rajat;
	[Space(10)]




	[Header("Manu")]
	public GameObject chromatic_manu;
	public Text chromatic_manu_highscore_text;
	public GameObject x, y;
	[Space(10)]


	[Header("Pause")]
	public GameObject rajat_game_pause;
	[Space(10)]


	[Header("GameOver")]
	public GameObject rajat_game_over;
	public GameObject highscore_panel;
	public float delay;
	public Text chromatic_gameover_highscore;
	public Text currentScore;
	public int highscore_chromatic;

	void Start () {
		FindObjectOfType<audio> ().play_chrom_background01 ();
		Time.timeScale = 0f;
		rajat_game_pause.SetActive (false);
		rajat_game_over.SetActive (false);
		chromatic_manu.SetActive (true);

		chromatic_manu_highscore_text.text ="Highscore "+ PlayerPrefs.GetInt ("highscore_chromatic", 0).ToString ();

		gameOver_rajat = false;
	
		score_chromatic = 0;
		miss = 0;

		chromatic_manu.GetComponent<Animator> ().SetBool ("start",false);

		x.SetActive (false);
		y.SetActive (false);
		//z.SetActive (false);
	}

	void Update () {
		ScoreText.text = score_chromatic.ToString ();
	}

	public void scoreupdate(int add){
		score_chromatic = score_chromatic + add;
	}

	public void miss_marble(int fall){
		miss = miss + fall;
		miss_text--;
		miss_display.text = miss_text.ToString ();


		if(miss >= 5){
			game_over_rajat ();
		}
	}


	public void game_over_rajat(){
		y.SetActive (false);
		gameOver_rajat = true;
		Time.timeScale = 0f;

		rajat_game_over.SetActive (true);
		highscore_panel.SetActive (false);
		currentScore.text = "Your Score is " + score_chromatic.ToString ();

		PlayerPrefs.SetInt ("chromatic_score",score_chromatic);

		playservices.instance.chro_addscore (score_chromatic);

		if (PlayerPrefs.GetInt ("chromatic_score", 0) > PlayerPrefs.GetInt ("highscore_chromatic")) {
			PlayerPrefs.SetInt ("highscore_chromatic", score_chromatic);
			highscore_panel.SetActive (true);
			chromatic_gameover_highscore.text = "HighScore is" + PlayerPrefs.GetInt ("highscore_chromatic", 0).ToString ();
		}
	}
		
	public void showleader(){
		FindObjectOfType<playservices> ().chro_showlead ();
	}

	public void close_chromatic_manu(){
		StartCoroutine (close());
	}

	IEnumerator close(){
		chromatic_manu.GetComponent<Animator> ().SetBool ("start",true);
		yield return new WaitForSecondsRealtime (1f);
		start_chromatic ();
	}

	public void play(){
		SceneManager.LoadScene (1);
	}

	public void start_chromatic(){
		Time.timeScale = 1f;
		chromatic_manu.SetActive (false);
		FindObjectOfType<audio> ().play_chrom_background01 ();
		x.SetActive (true);
		y.SetActive (true);
		//z.SetActive (true);
	}

	public void pause(){
		y.SetActive (false);
		Time.timeScale = 0f;
		rajat_game_pause.SetActive (true);
	}

	public void resume(){
		Time.timeScale = 1f;
		y.SetActive (true);
		rajat_game_pause.SetActive (false);
	}

	public void back_manu_chromatics(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}
}
