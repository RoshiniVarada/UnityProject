using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public bool hittable;

	public virtual void OnHit(GameObject hitter)
	{
		Destroy(gameObject);
	}
}
