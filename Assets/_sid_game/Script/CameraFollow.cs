using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	[Range(0,1)]
	public float smoothness = 0.1f; 

	public Vector3 tracker; //the distance of camera from the object

	void LateUpdate () {

		//so now the desired position of camera movement is currect position of the object and the distace of camera from object
		Vector3 desiredPosition = target.position + tracker;

		//lerp stands for linear interpolation , which actually moves a object from point A[tranform.position]to point B[desired position]...which has third argument t[smoothness] ,which lerps over time t
		Vector3 smoothedpostion = Vector3.Lerp (transform.position, desiredPosition, smoothness); //smoothness or t can be any value between 0 and 1;

		//and finally the delayed position of moving object will be on caamera
		transform.position = smoothedpostion;

	}
}
