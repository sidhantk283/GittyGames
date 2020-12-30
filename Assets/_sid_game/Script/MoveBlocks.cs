using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBlocks : MonoBehaviour {
	private float speed = 20f;
	public int level = 1;
	Rigidbody rb;

	UImanager uim;

	void Start(){
		rb = GetComponent<Rigidbody> ();

		//as each block is instantiated...its speed will increase by speed/20
		speed += (int)(Time.timeSinceLevelLoad/10f);
		Debug.Log (speed);
	
		if (speed >= 30f) {
			level=2;
		} else if (speed >= 40f & speed < 30f) {
			level=3;
		} else if (speed >= 50f & speed < 40f) {
			level=4;
		} else if (speed >= 60f & speed < 50f) {
			level=5;
		} else if (speed >= 70f & speed < 60f) {
			level=6;
		} else if (speed >= 80f & speed < 70f) {
			level=7;
		} else if (speed >= 90f & speed < 80f) {
			level=8;
		}


		FindObjectOfType<UImanager> ().display_level (level);
	}

	void Update () {
		
		if (this.gameObject.tag == "Block") {
			move ();
		} else if (this.gameObject.tag == "point") {
			move ();
		} 
	}

	void move(){
		transform.Translate (Vector3.back * speed * Time.deltaTime);
	}

		void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "BackCollider") {
			Destroy (this.gameObject);
		}
}
}
