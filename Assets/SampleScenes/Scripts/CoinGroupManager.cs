using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinGroupManager : MonoBehaviour {
	public int TotalCoins = 5; // make use of these to spawn different # coinss
	public Action SpawnRandomCoin;

	int currentCoins;

	public void Start()
	{
		currentCoins = TotalCoins;
		if (SpawnRandomCoin == null) 
		{
			throw new MissingComponentException ("Coin Spawner Missing...");
		}
	}

	public void CoinPicked()
	{
		currentCoins--;
		if (currentCoins <= 0) 
		{
			SpawnRandomCoin ();
		}
	}

	public void ActivateAllCoins() // make use of this function
	{
		for (int i = 0; i < transform.childCount; i++) 
		{
			transform.GetChild (i).gameObject.SetActive (true);
		}
	}
}
