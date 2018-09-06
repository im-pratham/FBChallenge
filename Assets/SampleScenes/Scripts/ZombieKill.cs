using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKill : MonoBehaviour, IKillable {
	public Animator ZombieAnimator;
	public RuntimeAnimatorController ZombieFallback;
	AIFollow aiFollow;

	public void Start()
	{
		aiFollow = GetComponent<AIFollow> ();
		if (aiFollow == null)
			throw new MissingComponentException ("aifollow missing...");
	}
	public void Kill()
	{
		Destroy (gameObject, 1);
		ZombieAnimator.runtimeAnimatorController = ZombieFallback;
		aiFollow.canMove = false;
	}
}
