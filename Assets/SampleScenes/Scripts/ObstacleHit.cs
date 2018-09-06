using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour {
	void OnCollisionEnter (Collision col) 
	{
		// Debug.Log (col.gameObject.name);
		ActivateHitables.HitAll (col.gameObject);
	}
}
