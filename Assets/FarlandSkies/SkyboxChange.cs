using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour {

	public Material[] sky;

	private float time_change = 0f;

	[Range(50,120)]
	public float next;

	void FixedUpdate () {
		
		if (Time.time >= time_change) {
			next = Random.Range (50,120);
			change_s ();
			time_change = Time.time + next;
		}
	}

	void change_s(){
		
		int s = Random.Range (0, sky.Length);
		RenderSettings.skybox = sky[s];
	}

}
