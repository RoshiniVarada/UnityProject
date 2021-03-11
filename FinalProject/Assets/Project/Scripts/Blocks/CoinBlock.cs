using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : Block
{
	public GameObject coinPrefab;
	public int coinAmount = 4;
	public GameObject coinSprite;

	public override void OnHit(Player player)
	{
		if (coinAmount > 0)
		{
			coinAmount--;

			GameObject coinInstance = GameObject.Instantiate(coinPrefab, transform.parent);
			coinInstance.transform.position = transform.position + Vector3.up * 1.2f;
			Destroy(coinInstance, 0.1f);
			player.AddCoin();
			if (coinAmount == 0)
			{
				coinSprite.SetActive(false);
				
			}

		}
	}
}
