using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {
	
	public int offsetX = 2;			//offset so that we dont get any weird errors
	
	//check if we need to instantiate stuff
	
	public bool hasATopBuddy = false;
	public bool hasABottomBuddy = false;

	
	
	private float spriteWidth = 0f; 
	private float spriteHeight = 0f;//the width of our element
	private Camera cam;
	private Transform myTransform;
	
	void Awake() {
		cam = Camera.main;
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start () {
		spriteWidth = 100;
		spriteHeight = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
		//does it still need buddies? if not do nothing
		if (!hasATopBuddy || !hasABottomBuddy ) {
			//calculate the cameras extend (half of width) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width/Screen.height;
			
			// calculate the x position where the camera can see the edge of the sprite
			float edgeVisiblePositionTop = (myTransform.position.z + spriteHeight/2) - camHorizontalExtend;
			float edgeVisiblePositionBottom = (myTransform.position.z - spriteHeight/2) + camHorizontalExtend;
			
			//check if we can see edge of element minus offset , make new buddy if we can
			if (cam.transform.position.z >= edgeVisiblePositionTop - offsetX && !hasATopBuddy){
				makeNewTopBottomBuddy(1);
				hasATopBuddy= true;
			} else if (cam.transform.position.z <= edgeVisiblePositionBottom - offsetX && !hasABottomBuddy){
				makeNewTopBottomBuddy(-1);
				hasABottomBuddy =true;
			}
		}
	}
	
	
	void makeNewTopBottomBuddy(int topOrBottom){
		//calc position for new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x, myTransform.position.y, myTransform.position.z + spriteHeight *topOrBottom);
		//instatiating new buddy and storing him in a variable
		Transform newBuddy = (Transform)Instantiate (myTransform, newPosition, myTransform.rotation);
		
		
		
		newBuddy.parent = myTransform.parent;
		if (topOrBottom > 0) {
			newBuddy.GetComponent<Tiling> ().hasABottomBuddy = true;
		} else {
			newBuddy.GetComponent<Tiling>().hasATopBuddy = true;
		}
	}







































}
