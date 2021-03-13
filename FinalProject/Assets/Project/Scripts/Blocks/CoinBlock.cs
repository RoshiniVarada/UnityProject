using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : Block
{
	public GameObject coinPrefab;
	public int coinAmount = 5;
	public Sprite brickSprite;

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
				gameObject.GetComponentInChildren<SpriteRenderer>().sprite = brickSprite;
			}
		}
	}
}
