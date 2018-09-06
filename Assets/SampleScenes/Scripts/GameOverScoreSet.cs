using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScoreSet : MonoBehaviour {
	public Text scoreText;
	public GameObject Player;
	// Use this for initialization
	void Awake () {
		int score = Player.GetComponent<Stats> ().Score;
		scoreText.text = "Your Score: " + score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
