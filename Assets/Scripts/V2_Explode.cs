using UnityEngine;
using System.Collections;

public class V2_Explode : MonoBehaviour {

	public GameObject explosion;
	
	void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "Terrain") 
		{
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
