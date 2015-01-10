using UnityEngine;
using System.Collections;

public class AAFire : MonoBehaviour {
	
	public float damageDistance = 4F;
	
	public GameObject exclamationMark;
	public GameObject explosion;
	
	private GameObject plane;
	private GameObject excl;
	private Vector3 explodePos;
	private ScoreManagerScript scoreManager;
	private PlaneHealthScript planeHealth;
	
	
	// Use this for initialization
	void Start () {
		plane = GameObject.FindGameObjectWithTag("FighterPlane");
		scoreManager = (ScoreManagerScript) GameObject.Find("ScoreManager").GetComponent("ScoreManagerScript");
		planeHealth = (PlaneHealthScript) GameObject.Find("PlaneHealth").GetComponent("PlaneHealthScript");
		
		explodePos = plane.transform.position;
		explodePos.x += getX ();
		explodePos.z += getZ ();
		
		Vector3 temp = new Vector3(explodePos.x - 13F, explodePos.y - 5F, explodePos.z + 17F);
		excl = (GameObject) Instantiate(exclamationMark, temp, plane.transform.rotation);
		excl.transform.Rotate(new Vector3(0, 180, 0));
		InvokeRepeating("excl_destroy", 0.5F, 1);
	}
	
	void excl_destroy()
	{
		CancelInvoke();
		Destroy (excl);
		InvokeRepeating("createExplosion", 1, 1);
	}
	
	void createExplosion()
	{
		CancelInvoke ();
		Instantiate(explosion, explodePos, plane.transform.rotation);
		if (Vector3.Distance (explodePos, plane.transform.position) <= damageDistance)
		{
			planeHealth.planeHit(51);
		}
	}
	
	private float getX()
	{
		int k = scoreManager.getKills();
		if (k < 50) return Random.Range (-70F, 70F);
		if (k < 100) return Random.Range (-50F, 50F);
		if (k < 150) return Random.Range (-30F, 30F);
		if (k < 200) return Random.Range (-20F, 20F);		
		return Random.Range (-70F, 70F);
	}
	
	private float getZ()
	{
		int k = scoreManager.getKills();
		if (k < 50) return Random.Range (-60F, 60F);
		if (k < 100) return Random.Range (-50F, 50F);
		if (k < 150) return Random.Range (-40F, 40F);
		if (k < 200) return Random.Range (-30F, 30F);		
		return Random.Range (-60F, 60F);
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
