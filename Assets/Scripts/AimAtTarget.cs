using UnityEngine;
using System.Collections;

public class AimAtTarget : MonoBehaviour {

	public GameObject flame;	
	public GameObject go_AAFire;
	
	void Start () {
		InvokeRepeating("InitiateShot", Random.Range (2, 5), 4);
	}
	
	// Update is called once per frame
	void Update () {}
	
	void InitiateShot()
	{
		if (GameObject.FindGameObjectWithTag("FighterPlane").transform.position.z > transform.position.z) CancelInvoke (); 
		Vector3 newPos = new Vector3(transform.position.x + 3F, transform.position.y + 3F, transform.position.z);
		Instantiate(flame, newPos, transform.rotation);
		Instantiate (go_AAFire, transform.position, transform.rotation);
	}
}
