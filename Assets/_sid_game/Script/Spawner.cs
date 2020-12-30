using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform[] spawnpoint;
	public GameObject blocks;


	public Transform[] pointspoint;
	public GameObject points;



	public Transform pluspointspoint;
	public GameObject plus_point ;


	private float timeBeweenWave = 5f; //the time between the next block will get spawned

	private float timeToSpawn = 1f; //When 1st block will get spawned

	void Awake(){
	}

	void FixedUpdate () {
		
			StartCoroutine (spawn());

	}

	IEnumerator spawn(){
		if (Time.time >= timeToSpawn) {

				SpawnBlocks ();

				timeToSpawn = Time.time + timeBeweenWave;

				yield return new WaitForSeconds (1.25f);

				spawnPoints ();

				yield return new WaitForSeconds (1.25f);

				spawnPoints ();

				yield return new WaitForSeconds (1.25f);

				spawnPoints ();
			
			}
		}

	void SpawnBlocks(){
		int random_Index = Random.Range (0, spawnpoint.Length); //selecting a random number from a range of numbers

		for (int i = 0; i < spawnpoint.Length; i++) {

			if (random_Index != i) {
				Instantiate (blocks,spawnpoint [i].position, Quaternion.identity);
				float empty = spawnpoint[i].position.x;
			}
		}
	}

	void spawnPoints(){
		int random_Index2 = Random.Range (0,pointspoint.Length);
		Instantiate (points, pointspoint [random_Index2].position, Quaternion.identity);
		float empty2 = pointspoint[random_Index2].position.x;
			}
		
}
