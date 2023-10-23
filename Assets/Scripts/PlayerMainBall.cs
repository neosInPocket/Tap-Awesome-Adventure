using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainBall : MonoBehaviour
{
	[SerializeField] private Transform barrier;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float gMultiplier;
	
	private void Update()
	{
		rb.AddForce(SetGravityForce());
	}
	
	private Vector2 SetGravityForce()
	{
		var groundDistance = Mathf.Abs(transform.position.x - barrier.position.x);
		var forceDirection = (- transform.position + barrier.transform.position).normalized;
		return gMultiplier * rb.mass / Mathf.Pow(groundDistance, 2) * forceDirection * Time.deltaTime;
	}
}
