using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
	public GameObject CoinPrefab;
	public int TotalSpawnGroups;

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
		TotalSpawnGroups = transform.childCount; // remove this
		SpawnCoinGroups ();
	}

	void SpawnCoinGroups()
	{
		for (int i = 0; i < TotalSpawnGroups; i++) 
		{
			SpawnRandomCoins ();
		}
	}
	void SpawnRandomCoins()
	{
		var spawnPoint = randomSpawnPoint;
		var position = Random.insideUnitSphere * 3 + spawnPoint.position;
		position.y = 1.37f;

		var coins = (GameObject) Instantiate (CoinPrefab, position, spawnPoint.rotation); // add parameter parent: randomSpawnPoint
		var script = coins.GetComponent<CoinGroupManager> ();
		script.SpawnRandomCoin += SpawnedCoinEnd;
	}

	void SpawnedCoinEnd() 
	{
		Debug.Log ("Spawning Random Coins...");
		SpawnRandomCoins ();
	}
}
