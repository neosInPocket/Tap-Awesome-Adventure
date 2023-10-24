using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CoinBall : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject killEffect;
	
	public void PlayKillEffect()
	{
		StartCoroutine(Kill());
	}
	
	private IEnumerator Kill()
	{
		spriteRenderer.color = new Color(0, 0, 0, 0);
		var effect = Instantiate(killEffect, transform.position, Quaternion.identity, transform);
		yield return new WaitForSeconds(1f);
		Destroy(effect);
	}
}
