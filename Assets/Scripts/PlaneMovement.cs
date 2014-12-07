using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {

	public float flySpeed = 0.2F;

	// Use this for initialization
	void Start () {
	
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
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + flySpeed);
	}

	void FlyBackwards()
	{
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - flySpeed);
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
