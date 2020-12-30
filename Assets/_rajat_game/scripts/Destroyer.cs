using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		//if (col.gameObject.tag =="redMarble"||col.gameObject.tag =="blueMarble"||col.gameObject.tag =="greenMarble") {
		//	Destroy (col.gameObject);
		//}	
		Destroy (col.gameObject);
		if(FindObjectOfType<colors>().is_blue == true && col.gameObject.tag =="blueMarble"){
			FindObjectOfType<uiManager2D> ().miss_marble (1);
		}else if(FindObjectOfType<colors>().is_green == true && col.gameObject.tag =="greenMarble"){
			FindObjectOfType<uiManager2D> ().miss_marble (1);
		}else if(FindObjectOfType<colors>().is_red == true && col.gameObject.tag =="redMarble"){
			FindObjectOfType<uiManager2D> ().miss_marble (1);
		}
	}
}
