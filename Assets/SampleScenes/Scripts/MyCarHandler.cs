using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Stats))]
public class MyCarHandler : MonoBehaviour {

	public Text scoreText;
	public AudioClip CoinPickupSound;
	public SimpleHealthBar healthBar;

	TextAnimator AddOnAnimator;
	Stats stat;
	AudioSource audioSource;

	void Start()
	{
		stat = GetComponent<Stats> ();
		scoreText.text = stat.Score.ToString();
		AddOnAnimator = GameObject.Find ("AddOnDiplay").GetComponent<TextAnimator>();
		audioSource = GetComponent<AudioSource> ();
		if (audioSource == null)
			throw new MissingComponentException ("audioSource missing...");
		if (AddOnAnimator == null)
			throw new MissingComponentException ("AddOnAnimator missing...");
	}
	void OnCollisionEnter (Collision col) 
	{
		// Debug.Log (col.gameObject.name);
		ActivateHitables.HitAll (col.gameObject);
	}

	void UpdateScore(int increment)
	{
		stat.Score += increment;
		scoreText.text = stat.Score.ToString ();
		AddOnAnimator.Display (string.Format("{0}+ Score", increment));
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag ("Pickable")) 
		{
			audioSource.PlayOneShot (CoinPickupSound);
			collider.gameObject.SetActive (false);
			UpdateScore (5);
		}
	}

	void Update()
	{
		healthBar.UpdateBar (stat.Health, 500);
	}
}
