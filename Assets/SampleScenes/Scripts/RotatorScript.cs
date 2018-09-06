using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour {
	CoinGroupManager coinManager;

	void Start() 
	{
		coinManager = GetComponentInParent<CoinGroupManager> ();
	}

	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			coinManager.CoinPicked ();
		}
	}
}
