using UnityEngine;
using System.Collections;

public class PlaneHealthScript : MonoBehaviour {

	private int health = 100; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void planeHit(int hpLoss)
	{
		health -= hpLoss;
		if (health < 50)
		{
			// Smoke?
		}
		if (health <= 0)
		{
			Application.LoadLevel("mainMenu");
		}
	}		
}
