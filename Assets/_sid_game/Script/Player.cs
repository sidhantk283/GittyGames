using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/* DESCRIPTION
Really simple surfing game.
You can enjoy for your short free time.

surf as far as u can without loosing 
impetus by dodging the obstacles and collect coins.

Create highscore and compete withe friends.Enjoy */


public class Player : MonoBehaviour {
	[Range(0,100)]
	public float horspeed = 10f;

	private float dirX;

	private Rigidbody rb;

	public float r;

	private float midpoint;

	UImanager uim;

	GameMaster gm;

	public bool check_gameover;

	public GameObject spark;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		midpoint = transform.localScale.x / 2;
		gm = GetComponent<GameMaster> ();
		check_gameover = false;
	}

	void Update(){
		dirX = CrossPlatformInputManager.GetAxis ("Horizontal") * horspeed;//* Time.deltaTime;
		rb.velocity = new Vector3 (dirX, 0, 0);

		//Raycaste bassically gives us a boolean value for eaither if its colliding withh other game object or not


		if (transform.position.x < midpoint) {
			r = 1f;
		} else if (transform.position.x > midpoint) {
			r = -1f;
		} else
		{
			r = 0;
		}



			Debug.DrawRay (transform.position + new Vector3 (r, 0, 0), Vector3.down,Color.red);

		if (! Physics.Raycast (transform.position + new Vector3 (r, 0, 0), Vector3.down, 1f)) {  
		
			//now here,if the ball isnt touching the platform ...its obviously falling...and the game will get over
			Debug.Log("padlo");
			rb.velocity=  new Vector3(0,-20f,0);
			FindObjectOfType<GameMaster> ().fall ();

			}
		}
	

	void OnCollisionEnter(Collision col){

		//if player colides with the block...the game manager will get run...with 5seconds of lag and game over

		if (col.gameObject.tag == "Block") {
			FindObjectOfType<audio> ().play_hit();
			Handheld.Vibrate ();
			check_gameover = true;
			FindObjectOfType<GameMaster> ().EndGame ();
		}

		if(col.gameObject.tag == "point"){
			FindObjectOfType<audio> ().play_coin ();
			GameObject particle = Instantiate (spark,col.gameObject.transform.position,Quaternion.identity);
			Destroy (col.gameObject);
			FindObjectOfType<UImanager> ().plus_score ();
		}
	}
}