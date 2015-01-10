using UnityEngine;
using System.Collections;

public class ExplodeMustard : MonoBehaviour {

	public GameObject mustard_explosion;
	
	void OnCollisionEnter(Collision other) 
	{
		if (other.collider.tag == "Terrain")
		{
			Instantiate(mustard_explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
