using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	Text timerText;
	// float startTime;
	public GameObject player;
	public GameObject GameOverButton;
	public int MaxGameTime;
	Toggle menuToggle;
	Stats stat;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		if (player == null)
			throw new MissingComponentException ("Player Missing");
		if (GameOverButton == null)
			throw new MissingComponentException ("GameOverUI Missing");

		menuToggle = GameOverButton.GetComponent<Toggle> ();

		stat = player.GetComponent<Stats> ();
		float startTime = Time.time;
		stat.endTime = startTime + MaxGameTime;
	}
	
	// Update is called once per frame
	void Update () {
		float timeInSecs = stat.endTime - Time.time;
		if (timeInSecs < 0f)
			timeInSecs = 0f;
		string tm = timeInSecs.ToString ("f2");
		timerText.text = tm;
		SetTimerColor (timeInSecs);
		if (timeInSecs <= 0f || stat.Health <= 0) {
			menuToggle.isOn = true;
		}
	}
	void SetTimerColor(float timeInSecs) {
		Color32 color;
		if (timeInSecs < 10f)
			color = new Color32 (255, 0, 0, 255);
		else
			color = new Color32 (255, 255, 255, 255);
		timerText.color = color;
	}
}
