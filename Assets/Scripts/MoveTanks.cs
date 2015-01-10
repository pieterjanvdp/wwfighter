using UnityEngine;
using System.Collections;

public class MoveTanks : MonoBehaviour {

	private bool isRotating = false;
	private int timesTurned = 0;
	private bool drivingBackwards = false;
	private int timesBackwards = 0;
	private bool drivingForward = true;

	private float rotationDirection = 0.3F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (drivingForward) 
		{
			if (transform.position.x > 80F) transform.Translate (Vector3.forward * Time.deltaTime * 5);
		}
		else if (drivingBackwards) 
		{
			transform.Translate (Vector3.back * Time.deltaTime * 5);
			timesBackwards++;
			if (timesBackwards > 60) {
				StartRotating ();
			}
		} 
		else if (isRotating) 
		{
			transform.Rotate (new Vector3 (0, rotationDirection, 0));
			timesTurned++;
			if (timesTurned > 130)
			{
				DriveForward();
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Bunker")
		{
			DriveBackwards();
		}
	}

	void DriveBackwards()
	{
		isRotating = false;
		drivingForward = false;

		drivingBackwards = true;
		timesBackwards = 0;
	}

	void StartRotating()
	{
		drivingForward = false;
		drivingBackwards = false;

		isRotating = true;
		timesTurned = 0;
		float temp = Random.Range (0, 10);
		if (temp > 5.0)
			rotationDirection = 0.3F;
		else
			rotationDirection = -0.3F;
	}

	void DriveForward()
	{
		isRotating = false;
		drivingBackwards = false;

		drivingForward = true;
		timesTurned = 0;
		timesBackwards = 0;
	}
}
