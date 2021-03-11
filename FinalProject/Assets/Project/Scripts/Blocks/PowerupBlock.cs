using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBlock : Block
{
	public GameObject powerupPrefab;
	//public Sprite brickSprite;

	private bool spawned;

	public override void OnHit(Player player)
	{
		if (!spawned)
		{
			spawned = true;

			GameObject powerupInstance = GameObject.Instantiate(powerupPrefab, transform.parent);
			powerupInstance.transform.position = transform.position + Vector3.up * 1.2f;

			//gameObject.GetComponentInChildren<SpriteRenderer>().sprite = brickSprite;
		}
	}
}
