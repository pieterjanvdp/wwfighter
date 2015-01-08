using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {


	private int playerScore;
	public GUIText text_kills;


	// Use this for initialization
	void Start () {
		playerScore = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void KillBunker()
	{
		addKills (3);
	}
	
	public void KillTank()
	{
		addKills(1);
	}
	
	private void addKills(int kills)
	{
		playerScore += kills;
		text_kills.text = "Kills: " + kills;
	}
}
