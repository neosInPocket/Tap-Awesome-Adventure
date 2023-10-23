using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	[SerializeField] private GameObject obstaclePrefab;
	[SerializeField] private Transform spawnPosition;
	
	private bool isEnabled;
	private bool isSpawned;
	
	private void Start()
	{
		isEnabled = true;
	}
	
	private void Update()
	{
		if (!isEnabled) return;
		if (isSpawned) return;
		
		StartCoroutine(Spawn());
	}
	
	public void On()
	{
		isEnabled = true;
	}
	
	public void Off()
	{
		isEnabled = false;
	}
	
	private IEnumerator Spawn()
	{
		if (!isEnabled || isSpawned) yield break;
		
		isSpawned = true;
		Instantiate(obstaclePrefab, spawnPosition.position, Quaternion.identity, transform);
		var spawnDelay = Random.Range(2f, 3f);
		yield return new WaitForSeconds(spawnDelay);
		
		isSpawned = false;
	}
}
