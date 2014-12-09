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
	
	}

	void dropBomb(eBombTypes bombType)
	{
		switch (bombType) 
		{
			case eBombTypes.BOMB_TYPE_STANDARD:
			{				
				Rigidbody clone;
				clone = Instantiate (rb_standard_bomb, transform.position, transform.rotation) as Rigidbody;
				clone.velocity = transform.TransformDirection (Vector3.forward * 10);
				break;
			}
			default:
			{
				break;
				// DO SOMETHING SHEEIIITTTT
			}
		}
	}
}
	