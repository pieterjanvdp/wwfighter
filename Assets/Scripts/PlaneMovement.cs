using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {

	public float flySpeed = 0.2F;
	public Camera mainCam;



	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindWithTag ("MainCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) { FlyForward(); }
		else if (Input.GetKey (KeyCode.DownArrow)) { FlyBackwards (); }
		else if (Input.GetKey (KeyCode.LeftArrow)) { StrafeLeft (); }
		else if (Input.GetKey (KeyCode.RightArrow)) { StrafeRight (); }
	}

	void FlyForward()
	{
		Vector3 viewPos = mainCam.WorldToViewportPoint(transform.position);//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.1f);
		if(viewPos.y <= 0.9) transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + flySpeed);
	}

	void FlyBackwards()
	{
		Vector3 viewPos = mainCam.WorldToViewportPoint(transform.position);		
		if(viewPos.y < 0.1) transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.1f);
		else transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - flySpeed);
	}

	void StrafeLeft()
	{
		transform.position = new Vector3 (transform.position.x - flySpeed, transform.position.y, transform.position.z);
	}

	void StrafeRight()
	{
		transform.position = new Vector3 (transform.position.x + flySpeed, transform.position.y, transform.position.z);
	}
}
