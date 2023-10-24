using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
	[SerializeField] private GameObject coinPrefab; 
	[SerializeField] private float coinSpawnChance;
	[SerializeField] private float speed;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Rigidbody2D rb;
	private bool isCoinSpawned;
	
	private void Start()
	{
		var rnd = Random.Range(0, 2);
		
		
		if (rnd == 0)
		{
			var leftPosition = -spriteRenderer.bounds.size.x / 2;
			transform.position = new Vector2(leftPosition, transform.position.y);
		}
		else
		{
			var leftPosition = spriteRenderer.bounds.size.x / 2;
			transform.position = new Vector2(leftPosition, transform.position.y);
		}
		
		SpawnCoin(transform.position);
		
		rb.velocity = Vector2.down * speed;
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<ObstacleDestroyTrigger>(out ObstacleDestroyTrigger trigger))
		{
			Destroy(gameObject);
		}
	}
	
	private void SpawnCoin(Vector2 obstaclePosition)
	{
		var screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		var rnd = Random.Range(0, 1f);
		if (rnd < coinSpawnChance)
		{
			if (obstaclePosition.x > 0)
			{
				var coinSP = Instantiate(coinPrefab, Vector2.zero, Quaternion.identity, transform).GetComponent<SpriteRenderer>();
				var position = new Vector2(screenBounds.x - coinSP.bounds.size.x, transform.position.y);
				coinSP.transform.position = position;
				return;
			}
			
			if (obstaclePosition.x < 0)
			{
				var coinSP = Instantiate(coinPrefab, Vector2.zero, Quaternion.identity, transform).GetComponent<SpriteRenderer>();
				var position = new Vector2(- screenBounds.x + coinSP.bounds.size.x, transform.position.y);
				coinSP.transform.position = position;
				return;
			}
		}
	}
}
