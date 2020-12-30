using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marble_spawnner : MonoBehaviour {

	public Transform position1;
	public GameObject []marble1;

	public Transform position2;
	public GameObject []marble2;

	public Transform position3;
	public GameObject []marble3;


	public float delayTimer = 5f;


	void FixedUpdate(){
		StartCoroutine (marble_spawn());
	}

	IEnumerator marble_spawn(){
		yield return new WaitForSeconds (5f);
		if (Time.time >= delayTimer) {

			spawn_marble1 ();

			spawn_marble2 ();

			spawn_marble3 ();

			delayTimer = Time.time + 1f;
		}
	}


	void spawn_marble1(){
		position1.position = new Vector3 (-2,Random.Range(5f,10f),0);

		int random_index1 = Random.Range (0,marble1.Length);
		Instantiate (marble1[random_index1],position1.position, Quaternion.identity);
		}

	void spawn_marble2(){
		position2.position = new Vector3 (0,Random.Range(5f,10f),0);

		int random_index2 = Random.Range (0,marble2.Length);
		Instantiate (marble2[random_index2],position2.position, Quaternion.identity);
	}

	void spawn_marble3(){
		position3.position = new Vector3 (2,Random.Range(5f,10f),0);

		int random_index3 = Random.Range (0,marble3.Length);
		Instantiate (marble3[random_index3],position3.position, Quaternion.identity);
	}
	}
