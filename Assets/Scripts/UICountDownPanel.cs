using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICountDownPanel : MonoBehaviour
{
	[SerializeField] private Animator animator;
	public Action OnCountEndAction;
	
	public void Play()
	{
		StartCoroutine(PlayAnimation());
	}
	
	private IEnumerator PlayAnimation()
	{
		animator.SetTrigger("play");
		yield return new WaitForSeconds(3f);
		OnCountEndAction?.Invoke();
	}
}
