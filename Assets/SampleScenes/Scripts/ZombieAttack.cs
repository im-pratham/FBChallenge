using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {
	public Transform player;
	public float attackRange = 3f;
	bool isCharging = false;
	public int attackDelay = 3;

	public Animator ZombieAnimator;
	public RuntimeAnimatorController ZombieAttackAnimation;
	public RuntimeAnimatorController ZombieWalkAnimation;

	bool IsInAttackRange 
	{
		get { return (Vector3.Distance (transform.position, player.position) < attackRange); }
	}

	Stats stat;

	void Start()
	{
		stat = GetComponent<Stats> ();
	}

	// Update is called once per frame
	void Update () {
		if (IsInAttackRange && !isCharging && stat.Health >= 0) 
		{
			Invoke ("Attack", attackDelay);
			isCharging = true;
			ZombieAnimator.runtimeAnimatorController = ZombieAttackAnimation;
		}
	}
	void Attack()
	{
		isCharging = false;

		if (IsInAttackRange && stat.Health <= 0) { // change the condition to !isInAttackRange || stat.Health <= 0
			Destroy (gameObject);
			return;
		}
		ActivateHitables.HitAll (player.gameObject);
		ZombieAnimator.runtimeAnimatorController = ZombieWalkAnimation;
	}
}
