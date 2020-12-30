using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
	[Header("Gameplay")]
	public int imp_score ;
	public int itime;
	public static int finalscore;
	public Text score;
	public Text hightscore;
	public Text t_bonus;
	public Text lvl;
	public Text final_score;
	public Text score_go;
	public Text hightscore_go;
	public Text t_bonus_go;
	public bool new_highcore;
	[Space(10)]

	[Header("Pause")]
	public GameObject gamePause;
	[Space(10)]

	[Header("GameOver")]
	public GameObject gameOverPanel;
	public GameObject highscorePanel;
	[Space(10)]

	[Header("manu")]
	public GameObject impetus_manu;
	public GameObject x, y, z, a ,b,cubie;

	void Start () {
		impetus_manu.GetComponent<Animator> ().SetBool ("started",false);
		Time.timeScale = 0f;
		FindObjectOfType<audio> ().play_imp_background01 ();
		gamePause.SetActive (false);
		new_highcore = false;
		gameOverPanel.SetActive (false);
		highscorePanel.SetActive (false);
		x.SetActive (false);
		y.SetActive (false);
		z.SetActive (false);
		a.SetActive (false);
		b.SetActive (false);
		cubie.SetActive (false);
		impetus_manu.SetActive (true);
	}

	void Update () {
		cur_score ();
		hightscore.text = "HighScore = " +  PlayerPrefs.GetInt ("highscore_impetus",0).ToString();
	}

	public void Play(){
		StartCoroutine (close());
	}

	IEnumerator close(){
		//impetus_manu.GetComponent<Animator> ().Play ("impetus_manu");
		impetus_manu.GetComponent<Animator> ().SetBool ("started",true);
		yield return new WaitForSecondsRealtime (1f);
		play_imp ();
	}

	public void play_imp(){
		Time.timeScale = 1f;
		x.SetActive (true);
		y.SetActive (true);
		z.SetActive (true);
		a.SetActive (true);
		b.SetActive (true);
		cubie.SetActive (true);
		impetus_manu.SetActive (false);
	}


	public void replay(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void pauseGame(){
		x.SetActive (false);
		y.SetActive (false);
		z.SetActive (false);
		a.SetActive (false);
		b.SetActive (false);
		cubie.SetActive (false);
		gamePause.SetActive (true);
		gamePause.GetComponent<Animator> ().Play ("Pause_panel");
		Time.timeScale = 0f;
	}

	public void resumeGame(){
		Time.timeScale = 1f;
		x.SetActive (true);
		y.SetActive (true);
		z.SetActive (true);
		a.SetActive (true);
		b.SetActive (true);
		cubie.SetActive (true);
		gamePause.SetActive (false);

	}

	public void Quit_manu(){
		SceneManager.LoadScene (0);
	}

	public void cur_score(){
		itime = (int)Time.timeSinceLevelLoad;
		t_bonus.text =itime.ToString ();
	}

	public void plus_score(){
		imp_score = imp_score + 5;
		score.text = imp_score.ToString();
	}

	public void final_scoredislay(){
		x.SetActive (false);
		y.SetActive (false);
		z.SetActive (false);
		a.SetActive (false);
		b.SetActive (false);
		cubie.SetActive (false);
		gameOverPanel.SetActive (true);

		playservices.instance.imp_addscore (imp_score);

		score_go.text = imp_score.ToString ();
		 
		int time_bon = (int)(itime / 3);
		t_bonus_go.text = time_bon.ToString ();


		finalscore = imp_score + time_bon;
		final_score.text = finalscore.ToString ();


		if (finalscore >= PlayerPrefs.GetInt ("highscore_impetus", 0)) {
			PlayerPrefs.SetInt ("highscore_impetus", finalscore);
			new_highcore = true;
			newHighscoreDisplay ();
		}
	}

	public void newHighscoreDisplay(){
		if (new_highcore == true) {
			highscorePanel.SetActive (true);
			hightscore_go.text = "New HighScore " + PlayerPrefs.GetInt ("highscore_impetus", 0);
		}
	}
	public void display_level(int l){
		lvl.text ="     Level " + l.ToString ();
	}
	public void MainMenu(){
		SceneManager.LoadScene (0);
	}

	public void showleader(){
		FindObjectOfType<playservices>().imp_showlead();
	}
}
