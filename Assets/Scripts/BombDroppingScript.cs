using UnityEngine;
using System.Collections;

public class BombDroppingScript : MonoBehaviour {

	public Transform rb_standard_bomb;
	public Transform rb_v2_bomb;
	public Transform rb_mustard_bomb;
	
	public float bombDropDelay = 0.5F;
	private bool canDrop = true;
	private int v2bombs;
	private int mustardGasBombs;
	
	private GameObject plane;

	enum eBombTypes {
		BOMB_TYPE_STANDARD,
		BOMB_TYPE_V2,
		BOMB_TYPE_MUSTARD
	}

	// Use this for initialization
	void Start () {
		v2bombs = 0;
		mustardGasBombs = 0;
		plane = (GameObject) GameObject.FindGameObjectWithTag("FighterPlane");
	}
	
	public void givev2Bomb()
	{
		v2bombs += 1;
	}

	public void giveMustardGasBomb() {
		mustardGasBombs += 1;
		Debug.Log ("done");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) { dropBomb(eBombTypes.BOMB_TYPE_STANDARD); }
		if (Input.GetKeyUp (KeyCode.A)) { dropBomb(eBombTypes.BOMB_TYPE_V2); }
		if (Input.GetKeyUp (KeyCode.M)) { dropBomb(eBombTypes.BOMB_TYPE_MUSTARD); }
	}
	
	void handleDelay()
	{
		CancelInvoke ();
		canDrop = true;	
	}

	void dropBomb(eBombTypes bombType)
	{
		Rigidbody clone;
		switch (bombType) 
		{
			case eBombTypes.BOMB_TYPE_STANDARD:
			{		
				if (canDrop)
				{
					clone = Instantiate (rb_standard_bomb, transform.position, transform.rotation) as Rigidbody;
					canDrop = false;
					InvokeRepeating("handleDelay", bombDropDelay, 10);
				}
				break;
			}
			case eBombTypes.BOMB_TYPE_V2:
			{
				if (v2bombs <= 0) break;
				clone = Instantiate (rb_v2_bomb, transform.position, transform.rotation) as Rigidbody;
				v2bombs--;
				break;
			}
			case eBombTypes.BOMB_TYPE_MUSTARD:
			{
				Debug.Log ("voor het check " + mustardGasBombs);
				if (mustardGasBombs <= 0) break;
				Debug.Log ("na het check");
				Vector3 spawnPosition = new Vector3(plane.transform.position.x, plane.transform.position.y - 10F, plane.transform.position.z);
				clone = Instantiate (rb_mustard_bomb, spawnPosition, transform.rotation) as Rigidbody;
				//clone.velocity = transform.TransformDirection (Vector3.forward * 10);
				mustardGasBombs--;
				break;
			}
			default:
			{
				break;
			}
		}
	}
}
	