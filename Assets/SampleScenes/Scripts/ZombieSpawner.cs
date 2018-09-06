using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

	public GameObject Zombie;
	public GameObject Player;
	public int ZombieKillIncrement = 5;
	public int ZombieCount;
	Stats stat;

	TextAnimator AddOnAnimator;

	int currentZombieCount;

	Transform randomSpawnPoint
	{
		get
		{
			int randInd = Random.Range (0, transform.childCount);
			return transform.GetChild (randInd);
		}
	}
	// Use this for initialization
	void Start () {
		stat = Player.GetComponent<Stats> ();
		if (stat == null)
			throw new MissingComponentException ("stats missing...");

		AddOnAnimator = GameObject.Find ("AddOnDiplay").GetComponent<TextAnimator>();
		if (AddOnAnimator == null)
			throw new MissingComponentException ("TimerAddOnAnimator missing...");
		
		SpawnZombies ();
	}

	void ZombieHasDied() 
	{
		currentZombieCount--;
		stat.endTime += ZombieKillIncrement;

		AddOnAnimator.Display (string.Format("+{0} Time", ZombieKillIncrement));

		if (currentZombieCount == 0) 
		{
			SpawnZombies ();
		}
	}

	void SpawnZombies()
	{
		currentZombieCount = ZombieCount;
		for (int i = 0; i < ZombieCount; i++) 
		{
			var position = Random.insideUnitSphere * 3 + randomSpawnPoint.position;
			position.y = 0;

			var zombie = (GameObject) Instantiate (Zombie, position, Quaternion.identity); // add parameter parent: randomSpawnPoint

			zombie.GetComponent<AIFollow> ().target = Player.transform;
			zombie.GetComponent<ZombieAttack> ().player = Player.transform;

			var hitDamage = zombie.GetComponent<HitDamage> ();
			hitDamage.hasDied += ZombieHasDied;
		}
	}
}
