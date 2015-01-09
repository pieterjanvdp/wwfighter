using UnityEngine;
using System.Collections;

public class AimAtTarget : MonoBehaviour {

	private GameObject plane;
	private Quaternion qTo;
	//private float maxDegreesPerSecond = 30.0F;

	// Use this for initialization
	void Start () {
		plane = GameObject.FindGameObjectWithTag("FighterPlane");
	}
	
	// Update is called once per frame
	void Update () {
				
		Vector3 relativePos = plane.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation(relativePos);
		
	
		/* 
		
		relativePos.y = 0;
		Vector3 newRotation;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
		
		Vector3 v3T = plane.transform.position - transform.position;
		v3T.y = transform.position.y;
		qTo = Quaternion.LookRotation(v3T, Vector3.up);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, maxDegreesPerSecond * Time.deltaTime);
		
		Vector3 relativePos = plane.transform.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = rotation;
	
		transform.LookAt (plane.transform.position); */
	}
}
