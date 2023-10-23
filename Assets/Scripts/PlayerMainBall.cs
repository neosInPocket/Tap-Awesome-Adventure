using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMainBall : BallAbstract
{
	[SerializeField] private float jumpAmplitude; 
	public Action<float> BarrierCollision;
	private float currentMaxSpeed;
	private bool isGrounded;
	public float GMultiplier => gMultiplier;
	
	public Action PlayerDamageTaken;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += OnFingerDownHandler;
	}

	protected override void UpdateLogic()
	{
		if (rb.velocity.x > currentMaxSpeed)
		{
			currentMaxSpeed = rb.velocity.x;
		}
	}

	private void OnFingerDownHandler(Finger finger)
	{
		if (!isGrounded) return;
		
		isGrounded = false;
		rb.velocity = new Vector2(-jumpAmplitude, 0);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.TryGetComponent<Barrier>(out Barrier barrier))
		{
			isGrounded = true;
			BarrierCollision?.Invoke(currentMaxSpeed);
			return;
		}
		
		if (collision.collider.TryGetComponent<MovingObstacle>(out MovingObstacle obstacle))
		{
			RaiseDamageTakenEvent();
			return;
		}
	}
	
	public void RaiseDamageTakenEvent()
	{
		PlayerDamageTaken?.Invoke();
	}
}
