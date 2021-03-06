﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {


	private int playerScore;
	public Text scoreGUIText;
	private int killCounter = 0;
	private BombDroppingScript bombDropping;
	public static int v2bombs = 0;
	public static int mustardGasBombs = 0;

	// Use this for initialization
	void Start () {
		playerScore = 0;	
		bombDropping = (BombDroppingScript) GameObject.Find("BombDropping").GetComponent("BombDroppingScript");
		scoreGUIText.text = "0  kills";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public int getKills()
	{
		return playerScore;
	}

	public void KillBunker()
	{
		addKills (3);
	}
	
	public void KillTank()
	{
		addKills(2);
	}
	
	public void KillAA()
	{
		addKills(1);
	}
	
	public void v2Impact()
	{
		addKills (7);
	}
	
	public void mustardGasBomb()
	{
		CancelInvoke ();
		InvokeRepeating("OvertimeKill", 5, 2);
	}
	
	private void OvertimeKill() {
		addKills (1);
		killCounter++;
		if (killCounter >= 15) CancelInvoke();
	}
	
	private void addKills(int kills)
	{
		playerScore += kills;
		if (playerScore % 10 == 0) v2bombs = v2bombs+ 1;
		if (playerScore % 20 == 0) mustardGasBombs = mustardGasBombs + 1;

		Debug.Log ("Player Score: " + playerScore);
		scoreGUIText.text = playerScore + "  kills";
	}
}
