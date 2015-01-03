#pragma strict

var plane : Transform;
var mainCam : Camera;

function Start () {

}

function Update () {
	var viewPos : Vector3 = mainCam.WorldToViewportPoint(plane.position);
	
	if(viewPos.y < 0.1){
		plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z + 0.1f);
	}
}