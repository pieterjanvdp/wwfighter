using UnityEngine;
using System.Collections;

public class BunkerHealth : MonoBehaviour {
	
	public int health = 120;
	public GameObject explosion;
	private ScoreManagerScript scoreManager;
		
	// Use this for initialization
	void Start () {
		scoreManager = (ScoreManagerScript) GameObject.Find("ScoreManager").GetComponent("ScoreManagerScript");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Bomb" || col.gameObject.tag == "V2") 
		{
			if (col.gameObject.tag == "V2") 
			{
				scoreManager.v2Impact();
				health -= 120;
			}
			Instantiate(explosion, transform.position, transform.rotation);
			health -= 51;
			if (health <= 0)
			{
				for (int i = 0; i < 5; i++) Instantiate(explosion, transform.position, transform.rotation);
				Destroy(this.gameObject);
				scoreManager.KillBunker ();
			}
			Destroy (col.gameObject);
		}
	}
}