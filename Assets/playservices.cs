using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class playservices : MonoBehaviour {
	public static playservices instance;

	public Text name;

	public Text added;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	void Start(){
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.Activate ();
		if(!PlayGamesPlatform.Instance.localUser.authenticated){
		login ();
		}
	}

	void Update(){
		if(PlayGamesPlatform.Instance.localUser.authenticated){
		name.text = PlayGamesPlatform.Instance.localUser.userName.ToString ();
		}
	}


	void login(){
		PlayGamesPlatform.Instance.localUser.Authenticate (success => {});
	}

	public void imp_addscore(int score){
		Debug.Log ("Score added "+score);
		PlayGamesPlatform.Instance.ReportScore (score,leaderboard.leaderboard_impetus,(success)=>{
			
		});
	}
		
	public void zz_addscore(int score){
		Debug.Log ("Score added "+score);
		PlayGamesPlatform.Instance.ReportScore (score,leaderboard.leaderboard_zigzagtrail,(success)=>{
			
		});
	}

	public void chro_addscore(int score){
		Debug.Log ("Score added "+score);
		PlayGamesPlatform.Instance.ReportScore (score,leaderboard.leaderboard_chromatic,(success)=>{
			
		});
	}

	public void imp_showlead(){
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderboard.leaderboard_impetus);
		} else {
			login ();
		}
	}

	public void zz_showlead(){
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderboard.leaderboard_zigzagtrail);
		} else {
			login ();
		}
	}


	public void chro_showlead(){
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderboard.leaderboard_chromatic);
		} else {
			login ();
		}
	}
}
