using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHitables : MonoBehaviour {

	public static void HitAll(GameObject gameObject)
	{
		var hitables = gameObject.GetComponents(typeof(IHitable));
		if (hitables == null)
			return;
		// Debug.Log ("hitables# " + hitables.Length);
		foreach (IHitable hitable in hitables) 
		{
			hitable.Hit ();
		}
	}
}
