using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointComplete : MonoBehaviour {
	public GameObject GameOverButton;
	Toggle menuToggle;
	public Text Title;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag ("Player")) 
		{
			Debug.Log ("You Won !");
			Title.text = "You Won !";
			menuToggle = GameOverButton.GetComponent<Toggle> ();
			menuToggle.isOn = true;
		}
	}
}
