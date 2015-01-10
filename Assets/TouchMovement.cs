using UnityEngine;
using System.Collections;

public class TouchMovement : MonoBehaviour {

	public float flySpeed = 0.2F;
	public Camera mainCam;
	public Transform plane;

	private bool movingForward = false;
	private bool movingBackward = false;
	private bool movingRight = false;
	private bool movingLeft = false;
	
	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindWithTag ("MainCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (movingForward) { FlyForward(); }
		if (movingBackward) { FlyBackwards(); }
		if (movingLeft) { StrafeLeft(); }
		if (movingRight) { StrafeRight(); }
		/*else if (Input.GetKey (KeyCode.DownArrow)) { FlyBackwards (); }
		else if (Input.GetKey (KeyCode.LeftArrow)) { StrafeLeft (); }
		else if (Input.GetKey (KeyCode.RightArrow)) { StrafeRight (); }*/
	}
	
	public void FlyForward()
	{
		movingForward = true;
		Vector3 viewPos = mainCam.WorldToViewportPoint(plane.position);//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.1f);
		if(viewPos.y <= 0.9) plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z + flySpeed);
	}

	public void StopFlyForward()
	{
		movingForward = false;
		}

	public void FlyBackwards()
	{
		movingBackward = true;
		Vector3 viewPos = mainCam.WorldToViewportPoint(plane.position);		
		if(viewPos.y < 0.1) plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z + 0.1f);
		else plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z - flySpeed);
	}

	public void StopFlyBackward()
	{
		movingBackward = false;
	}

	public void StrafeLeft()
	{
		movingLeft = true;
		plane.position = new Vector3 (plane.position.x - flySpeed, plane.position.y, plane.position.z);
	}

	public void StopStrafeLeft()
	{
		movingLeft = false;
		}
	
	public void StrafeRight()
	{
		movingRight = true;
		plane.position = new Vector3 (plane.position.x + flySpeed, plane.position.y, plane.position.z);
	}

	public void StopStrafeRight()
	{
		movingRight = false;
	}
}
