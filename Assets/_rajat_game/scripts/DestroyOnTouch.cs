using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {
	void OnMouseDown(){
		if(FindObjectOfType<uiManager2D>().gameOver_rajat==false){
		if (FindObjectOfType<colors> ().is_blue == true) {
				if (gameObject.tag == "blueMarble") {
					Debug.Log ("blue");
					Destroy (gameObject);
					FindObjectOfType<audio> ().play_touch_marble ();
					FindObjectOfType<uiManager2D> ().scoreupdate (1);
				} else if (gameObject.tag == "greenMarble") {
					Debug.Log ("wrong");
					Destroy (gameObject);
					FindObjectOfType<uiManager2D> ().game_over_rajat ();
				} else if (gameObject.tag == "redMarble") {
					Debug.Log ("wrong");
					Destroy (gameObject);
					FindObjectOfType<uiManager2D> ().game_over_rajat ();
				}
			}
			if (FindObjectOfType<colors> ().is_green == true) {
				if (gameObject.tag == "blueMarble") {
					Debug.Log ("wrong");
					Destroy (gameObject);
					FindObjectOfType<uiManager2D> ().game_over_rajat ();
				} else if (gameObject.tag == "greenMarble") {
					Debug.Log ("green");
					Destroy (gameObject);
					FindObjectOfType<audio> ().play_touch_marble ();
					FindObjectOfType<uiManager2D> ().scoreupdate (1);
				} else if (gameObject.tag == "redMarble") {
					Debug.Log ("wrong");
					Destroy (gameObject);
					FindObjectOfType<uiManager2D> ().game_over_rajat ();
				}
			}
			if (FindObjectOfType<colors> ().is_red == true) {
				if (gameObject.tag == "blueMarble") {
					Debug.Log ("wrong");
					Destroy (gameObject);
					FindObjectOfType<uiManager2D> ().game_over_rajat ();
				} else if (gameObject.tag == "greenMarble") {
					Debug.Log ("wrong");
					Destroy (gameObject);
					FindObjectOfType<uiManager2D> ().game_over_rajat ();
				} else if (gameObject.tag == "redMarble") {
					Debug.Log ("red");
					Destroy (gameObject);
					FindObjectOfType<audio> ().play_touch_marble ();
					FindObjectOfType<uiManager2D> ().scoreupdate (1);
				}
			}
		}
	}
}