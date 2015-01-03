using UnityEngine;
using System.Collections;

public class BunkerHealth : MonoBehaviour {
	
	public int health = 100;
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Bomb") 
		{
			Destroy (col.gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			health -= 51;
			Debug.Log ("giovanni");
			if (health <= 0)
			{
				Destroy(this.gameObject);
			}
		}
	}
}