using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Stats))]
public class HitDamage : MonoBehaviour, IHitable {
	Stats stat;
	IKillable killable;
	bool isDead = false;
	public Action hasDied;

	public void Start() 
	{
		stat = GetComponent<Stats> ();
		killable = (IKillable) GetComponent (typeof(IKillable));
		if (killable == null)
			throw new MissingComponentException ("killable missing...");
	}

	public void Hit() {
		stat.Health -= 10;
		if (stat.Health <= 0 && !isDead) 
		{
			killable.Kill ();

			if (hasDied != null) 
			{
				hasDied ();
			}
			isDead = true;
		}
	}
}
