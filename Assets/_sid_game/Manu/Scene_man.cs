using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_man : MonoBehaviour {
	public Animator option_anim;

	[Space(10)]
	public GameObject game_option;
	public GameObject a,b,c;

	[Space(10)]
	public GameObject imp, zz, chro;


	void Start(){
		FindObjectOfType<audio> ().play_main_manu_background ();
		a.SetActive (true);
		b.SetActive (true);
		c.SetActive (true);
		game_option.SetActive (false);	
	}
		
	public void openoptions(){
		a.SetActive (false);
		c.SetActive (false);
		game_option.SetActive (true);
		b.GetComponent<Animator> ().SetBool ("stop",true);
		option_anim.SetBool ("isclose",false);
		option_anim.SetBool ("isopen",true);
	}

	public void closeoptions(){
		option_anim.SetBool ("isopen",false);
		option_anim.SetBool ("isclose",true);
		b.GetComponent<Animator> ().SetBool ("stop",false);
		a.SetActive (true);
		c.SetActive (true);
		game_option.SetActive (false);
	}

	public void gitty_games__manu(){
		SceneManager.LoadScene (0);	
	}

	public void impetus(){
		SceneManager.LoadScene (2);
	}

	public void chromatic_manu(){
		SceneManager.LoadScene (1);	
	}

	public void zigzag_manu(){
		SceneManager.LoadScene (3);	
	}

	public void zz_howto(){
		Debug.Log ("pressed");
	}


	public void openhowto_imp(){
		imp.SetActive (true);
		game_option.SetActive (false);
	}
	public void closehowto_imp(){
		imp.SetActive (false);
		game_option.SetActive (true);
	}


	public void openhowto_chro(){
		chro.SetActive (true);
		game_option.SetActive (false);
	}
	public void closehowto_chro(){
		chro.SetActive (false);
		game_option.SetActive (true);
	}

	public void QuitGame(){
		Application.Quit ();
		Debug.Log ("Quit");
	}


	public void openhowto_zz(){
		zz.SetActive (true);
		game_option.SetActive (false);
	}
	public void closehowto_zz(){
		zz.SetActive (false);
		game_option.SetActive (true);
	}
}
