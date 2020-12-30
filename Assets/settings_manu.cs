using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings_manu : MonoBehaviour {

	public GameObject settings_panel;

	public GameObject a,b,c;

	void Start (){
		a.SetActive (true);
		b.SetActive (true);
		c.SetActive (true);
		settings_panel.SetActive (false);
		PlayerPrefs.SetFloat ("masterVolume",1); //default value of volume will be 1
	}

	public void ClickSettings(){
		a.SetActive (false);
		b.SetActive (false);
		c.SetActive (false);
		settings_panel.GetComponent<Animator> ().Play ("open",0);
		settings_panel.SetActive (true);
	}

	public void backManu(){
		a.SetActive (true);
		b.SetActive (true);
		c.SetActive (true);
		settings_panel.SetActive (false);
	}

	public void setVolum(float ggvolume){ 	//if the user needs to change volume he can fromthis slider and will be stored in masterVolume playerpref
		PlayerPrefs.SetFloat ("masterVolume",ggvolume);
	}

	public void setQuality(int qualIndex){	//basically this is quality of game u'll have...bydefault its at medium
		QualitySettings.SetQualityLevel (qualIndex);

	}

}
