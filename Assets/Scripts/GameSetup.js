#pragma strict

var mainCam : Camera;

var rightWall : BoxCollider;

function Start () {

rightWall.size = new Vector3(mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f, 1f);
rightWall.center = new Vector3(0f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y + 0.5f, 0f);

}

function Update () {

}