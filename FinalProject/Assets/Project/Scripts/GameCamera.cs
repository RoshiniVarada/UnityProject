using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
	public Player player;
	public Vector3 offset;
	public float minimumY;
	public float smoothFactor;

	private bool win;

	// Use this for initialization
	void Start()
	{
		player.OnWin += OnWin;
	}

	// FixedUpdate is called on a fixed time interval
	void FixedUpdate()
	{
		if (player != null && player.Dead == false && win == false)
		{
			Vector3 targetPosition = new Vector3(
										offset.x + player.transform.position.x,
										Mathf.Max(offset.y + player.transform.position.y, minimumY),
										offset.z + transform.position.z
									);

			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
		}
	}

	void OnWin()
	{
		win = true;
	}
}
