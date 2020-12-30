using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class colors : MonoBehaviour {
	public Sprite image1;

	public Sprite image2;

	public Sprite image3;

	Sprite[] image;

	public Image renderer_image;

	public float delayTimer;

	[Range(0,30f)]
	public float timebetweensprites;


	public bool is_blue, is_red, is_green;


	public Image time_bar;


	public Animator bar;

	public GameObject next_sprite;


	//public bool sprite_over;

	void Start () {
		next_sprite.SetActive (false);

		delayTimer = 0f;

		image = new Sprite[] {image1,image2,image3};

		is_blue = false;
		is_green = false;
		is_red = false;
	}
		
	void Update(){
		StartCoroutine(change_sprite_after_function());
	}

	IEnumerator change_sprite_after_function(){
		yield return "done";

		if (Time.time >= delayTimer) {
			is_blue = false;
			is_green = false;
			is_red = false;

			change_sprite ();

			delayTimer = Time.time + timebetweensprites;
		}
	}

	public void change_sprite(){
		int i = Random.Range (0,3);
		renderer_image.sprite = image[i];

		if (i == 0) {
			is_blue = true;
		}
		else if (i == 1) {
			is_green = true;
		}
		else if (i == 2) {
			is_red = true;
		}
	}
}
