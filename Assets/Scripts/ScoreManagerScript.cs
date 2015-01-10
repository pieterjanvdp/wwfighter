using UnityEngine;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {


	private int playerScore;
	public GUIText text_kills;


	// Use this for initialization
	void Start () {
		playerScore = 0;	
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
	
	private void addKills(int kills)
	{
		playerScore += kills;
		Debug.Log ("Player Score: " + playerScore);
		//text_kills.text = "Kills: " + kills;
	}
}
