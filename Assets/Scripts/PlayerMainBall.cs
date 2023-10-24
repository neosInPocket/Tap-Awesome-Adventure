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
	[SerializeField] private SpriteRenderer playerSpriteRenderer;
	[SerializeField] private SpriteRenderer secondBallSpriteRenderer;
	[SerializeField] private float jumpAmplitude; 
	public Action<float> BarrierCollision;
	private float currentMaxSpeed;
	private bool isGrounded;
	public float GMultiplier => gMultiplier;
	
	public Action PlayerDamageTaken;
	public Action CoinCollectedEvent;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		rb.angularVelocity = 2;
	}
	
	public void EnableControls()
	{
		Touch.onFingerDown += OnFingerDownHandler;
	}
	
	public void DisableControls()
	{
		Touch.onFingerDown -= OnFingerDownHandler;
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
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<MovingObstacle>(out MovingObstacle obstacle))
		{
			RaiseDamageTakenEvent();
		}
		
		if (collider.TryGetComponent<CoinBall>(out CoinBall coinBall))
		{
			RaiseCoinCollectedEvent();
			coinBall.PlayKillEffect();
		}
	}
	
	public void GetDamage()
	{
		StartCoroutine(TakeDamageEffect());
	}
	
	private IEnumerator TakeDamageEffect()
	{
		bool exit = false;
		int counter = 0;
		while (!exit)
		{
			if (counter == 7)
			{
				exit = true;
				yield break;
			}
			
			playerSpriteRenderer.color = new Color(1, 1, 1, 0.3f);
			secondBallSpriteRenderer.color = new Color(1, 1, 1, 0.3f);
			yield return new WaitForSeconds(0.2f);
			playerSpriteRenderer.color = new Color(1, 1, 1, 1f);
			secondBallSpriteRenderer.color = new Color(1, 1, 1, 1f);
			yield return new WaitForSeconds(0.2f);
			counter++;
		}
	}
	
	public void RaiseDamageTakenEvent()
	{
		PlayerDamageTaken?.Invoke();
	}
	
	public void RaiseCoinCollectedEvent()
	{
		CoinCollectedEvent?.Invoke();
	}
	
	private void OnDestroy()
	{
		DisableControls();
	}
}
