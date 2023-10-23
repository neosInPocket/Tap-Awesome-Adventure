using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondBall : BallAbstract
{
	[SerializeField] private PlayerMainBall player;
	private bool isGrounded;
	
	private void Start()
	{
		player.BarrierCollision += OnPlayerBarrierCollided;
		gMultiplier = player.GMultiplier;
	}
	
	private void OnPlayerBarrierCollided(float speedValue)
	{
		if (!isGrounded) return;
		isGrounded = false;
		rb.velocity = new Vector2(speedValue, 0);
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.TryGetComponent<Barrier>(out Barrier barrier))
		{
			isGrounded = true;
			return;
		}
		
		if (collision.collider.TryGetComponent<MovingObstacle>(out MovingObstacle obstacle))
		{
			player.RaiseDamageTakenEvent();
			return;
		}
	}
}
