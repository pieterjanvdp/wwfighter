using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour {

	public Transform tank;

	private GameObject fighterPlane;
	private GameObject mainTerrain;
	private GameObject bunker;


	// Use this for initialization
	void Start () {
		fighterPlane = GameObject.FindWithTag ("FighterPlane");
		mainTerrain = GameObject.FindWithTag ("Terrain");
		bunker = GameObject.FindWithTag ("Bunker");
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
		Transform clone;
		Random rnd = new Random ();
		for (int i = 0; i < 3; i++) {
			Vector3 bunkerPos = new Vector3 (transform.position.x + Random.Range (100F, 165), transform.position.y + 5F, transform.position.z + (20F * (i+1) + 4F));
			clone = Instantiate (bunker, bunkerPos, transform.rotation) as Transform;
		}
	}

	void createAntiAir()
	{
	
	}
	
	void createTanks()
	{
		Transform clone;
		for (int i = 0; i < 3; i++) {
			Vector3 tankPos = new Vector3 (transform.position.x + 180F, transform.position.y + 5F, transform.position.z + (20F * (i+1) + 4F));
			clone = Instantiate (tank, tankPos, transform.rotation) as Transform;
			clone.Rotate (new Vector3 (0, 270, 0));
		}

	}
}
