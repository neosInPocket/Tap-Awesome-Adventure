using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] private Image inner;
	[SerializeField] private TMP_Text text;
	
	public void UpdateProgress(float currentProgress, float allProgress)
	{
		text.text = currentProgress + "/" + allProgress;
		float value = currentProgress / allProgress;
		inner.fillAmount = value;
	}
}
