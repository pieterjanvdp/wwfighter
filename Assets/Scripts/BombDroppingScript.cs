using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombDroppingScript : MonoBehaviour {

	public Transform rb_standard_bomb;
	public Transform rb_v2_bomb;
	public Transform rb_mustard_bomb;
	public Text txt_bombStack;
	
	public float bombDropDelay = 0.5F;
	private bool canDrop = true;


	
	private GameObject plane;

	enum eBombTypes {
		BOMB_TYPE_STANDARD,
		BOMB_TYPE_V2,
		BOMB_TYPE_MUSTARD
	}

	// Use this for initialization
	void Start () {
		plane = (GameObject) GameObject.FindGameObjectWithTag("FighterPlane");
	}


	void OnGUI(){
		txt_bombStack.text = "Mustard: " + ScoreManagerScript.mustardGasBombs + "\nV2: " + ScoreManagerScript.v2bombs;
	
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

	public void dropStandard(){
		dropBomb (eBombTypes.BOMB_TYPE_STANDARD);

	}

	public void dropV2(){
		dropBomb (eBombTypes.BOMB_TYPE_V2);

	}

	public void dropMustard(){
		dropBomb (eBombTypes.BOMB_TYPE_MUSTARD);
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
				clone = Instantiate (rb_standard_bomb, plane.transform.position, plane.transform.rotation) as Rigidbody;
					canDrop = false;
					InvokeRepeating("handleDelay", bombDropDelay, 10);
				}
				break;
			}
			case eBombTypes.BOMB_TYPE_V2:
			{

				if (ScoreManagerScript.v2bombs <= 0) break;

			clone = Instantiate (rb_v2_bomb, plane.transform.position, plane.transform.rotation) as Rigidbody;
				ScoreManagerScript.v2bombs--;
	
				break;
			}
			case eBombTypes.BOMB_TYPE_MUSTARD:
			{
	
				if (ScoreManagerScript.mustardGasBombs <= 0) break;
				Debug.Log ("na het check");
				Vector3 spawnPosition = new Vector3(plane.transform.position.x, plane.transform.position.y - 10F, plane.transform.position.z);
			clone = Instantiate (rb_mustard_bomb, spawnPosition, plane.transform.rotation) as Rigidbody;
				//clone.velocity = transform.TransformDirection (Vector3.forward * 10);
			ScoreManagerScript.mustardGasBombs--;
		
				break;
			}
			default:
			{
				break;
			}
		}
	}
}
	