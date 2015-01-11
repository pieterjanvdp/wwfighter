using UnityEngine;
using System.Collections;

public class GarbageCollecting : MonoBehaviour
{

		private GameObject plane;

		// Use this for initialization
		void Start ()
		{
				plane = GameObject.FindGameObjectWithTag ("FighterPlane");
				InvokeRepeating ("StartCollecting", 30, 10);	
		}
	
		// Update is called once per frame
		void Update ()
		{

	
		}

		private void StartCollecting ()
		{/*
				GameObject[] allObjects = GameObject.FindObjectsOfType (GameObject);
				for (int i = 0; i < allObjects.Length; i++) {
						if (allObjects [i].transform.position.z < plane.transform.position.z - 100F) {
								Destroy (allObjects [i]);
						}
				}*/
		}
}
