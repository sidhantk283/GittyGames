using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Papae.UnitySDK.Managers;

public class GameMaster : MonoBehaviour {
	private float slowness = 10f;

	public void EndGame(){
		
		StartCoroutine (Restart1());
	}


	public void fall(){
		//Debug.Log ("Padlo");
		StartCoroutine (Restart2 ());
	}



	IEnumerator Restart1(){		//rstart with slow-mo
		//before 5 seconds

		//when hit by a block a slo-mo effect will be given
		Time.timeScale = 1f/slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

		yield return new WaitForSeconds(5f/slowness);//wait for 5 sec.......devide by slowness because it should get 5sec in real-time

		//after 5 seconds

		//Now that the 5secs are over we will change the scene..and return time to original value
		Time.timeScale = 0f;


		//Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
		FindObjectOfType<UImanager> ().final_scoredislay ();
	}

	IEnumerator Restart2(){		//restart without slow-mo
		yield return new WaitForSeconds (0.5f);

		//after 5 seconds
		Time.timeScale = 0f;
		FindObjectOfType<UImanager> ().final_scoredislay ();
	}
}
