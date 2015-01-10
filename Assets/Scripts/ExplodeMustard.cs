using UnityEngine;
using System.Collections;

public class ExplodeMustard : MonoBehaviour {

	public GameObject mustard_explosion;
	
	private ScoreManagerScript scoreManager;
	
	void Start() {
		scoreManager = (ScoreManagerScript) GameObject.Find("ScoreManager").GetComponent("ScoreManagerScript");
	}
	
	void OnCollisionEnter(Collision other) 
	{
		if (other.collider.tag == "Terrain")
		{
			scoreManager.mustardGasBomb();
			Instantiate(mustard_explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
