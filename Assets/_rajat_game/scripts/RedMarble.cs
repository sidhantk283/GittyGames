using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMarble : MonoBehaviour {
	private float speed = 5f;

	void Update () {
		transform.Translate (Vector2.down * speed * Time.deltaTime);	
	}
}
