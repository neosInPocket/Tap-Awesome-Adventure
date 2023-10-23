using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallAbstract : MonoBehaviour
{
	[SerializeField] private Transform barrier;
	[SerializeField] protected Rigidbody2D rb;
	[SerializeField] protected float gMultiplier;
	
	private void Update()
	{
		rb.AddForce(SetGravityForce());
		
		UpdateLogic();
	}
	
	private Vector2 SetGravityForce()
	{
		var groundDistance = Mathf.Abs(transform.position.x - barrier.position.x);
		var forceDirection = (- transform.position + barrier.transform.position).normalized;
		var normalizedForceDirection = new Vector2(forceDirection.x, 0);
		return gMultiplier * rb.mass / Mathf.Pow(groundDistance, 1) * normalizedForceDirection * Time.deltaTime;
	}
	
	protected virtual void UpdateLogic()
	{
	
	}
}
