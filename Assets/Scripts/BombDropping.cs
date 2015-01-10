using UnityEngine;
using System.Collections;

public class BombDropping : MonoBehaviour {

	public Transform rb_standard_bomb;
	public Transform rb_v2_bomb;
	public Transform rb_mustard_bomb;

	enum eBombTypes {
		BOMB_TYPE_STANDARD,
		BOMB_TYPE_V2,
		BOMB_TYPE_MUSTARD
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) { dropBomb(eBombTypes.BOMB_TYPE_STANDARD); }
		if (Input.GetKeyUp (KeyCode.A)) { dropBomb(eBombTypes.BOMB_TYPE_V2); }
		if (Input.GetKeyUp (KeyCode.M)) { dropBomb(eBombTypes.BOMB_TYPE_MUSTARD); }
	}

	void dropBomb(eBombTypes bombType)
	{
		Rigidbody clone;
		switch (bombType) 
		{
			case eBombTypes.BOMB_TYPE_STANDARD:
			{					
				clone = Instantiate (rb_standard_bomb, transform.position, transform.rotation) as Rigidbody;
				//GEEFT ERROR IN CONSOLEclone.velocity = transform.TransformDirection (Vector3.forward * 10);
				break;
			}
			case eBombTypes.BOMB_TYPE_V2:
			{
				clone = Instantiate (rb_v2_bomb, transform.position, transform.rotation) as Rigidbody;
				//clone.velocity = transform.TransformDirection (Vector3.forward * 10);
				break;
			}
			case eBombTypes.BOMB_TYPE_MUSTARD:
			{
				Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 10F, transform.position.z);
				clone = Instantiate (rb_mustard_bomb, spawnPosition, transform.rotation) as Rigidbody;
				//clone.velocity = transform.TransformDirection (Vector3.forward * 10);
				break;
			}
			default:
			{
				break;
			}
		}
	}
}
	