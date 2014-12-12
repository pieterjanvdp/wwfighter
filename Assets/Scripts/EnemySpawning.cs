using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour {

	public Transform tank;


	// Use this for initialization
	void Start () {
		createEnemies ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createEnemies() {
		createTanks ();
		createBunkers ();
		createAntiAir ();
	}

	void createBunkers()
	{
	
	}

	void createAntiAir()
	{
	
	}
	
	void createTanks()
	{
		GameObject fighterPlane = GameObject.FindWithTag ("FighterPlane");
		GameObject mainTerrain = GameObject.FindWithTag ("Terrain");
		Vector3 tankPos = new Vector3 (fighterPlane.transform.position.x + 1, mainTerrain.transform.position.y, fighterPlane.transform.position.z + 0.5F);
		Rigidbody clone;
		clone = Instantiate (tank, tankPos, mainTerrain.transform.rotation) as Rigidbody;
	}
}
