using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour {

	public Transform tank;

	private GameObject fighterPlane;
	private GameObject mainTerrain;


	// Use this for initialization
	void Start () {
		fighterPlane = GameObject.FindWithTag ("FighterPlane");
		mainTerrain = GameObject.FindWithTag ("Terrain");
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
		Transform clone;
		for (int i = 0; i < 3; i++) {
			Vector3 tankPos = new Vector3 (fighterPlane.transform.position.x + 85F, mainTerrain.transform.position.y + 5F, fighterPlane.transform.position.z + (0.5F * (i+1) + 2F));
			clone = Instantiate (tank, tankPos, transform.rotation) as Transform;
			Debug.Log (clone);
			clone.Rotate (new Vector3 (0, 270, 0));
		}

	}
}
