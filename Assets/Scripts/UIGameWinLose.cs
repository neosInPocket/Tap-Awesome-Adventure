using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameWinLose : MonoBehaviour
{
    [SerializeField] private GameObject panelContainer;
	[SerializeField] private TMP_Text resultText;
	[SerializeField] private TMP_Text coinsText;
	[SerializeField] private GameObject coinContainer;
	
	
	public void Show(bool win, int coins)
	{
		panelContainer.SetActive(true);
		
		if (!win)
		{
			resultText.text = "Lose";
			coinContainer.gameObject.SetActive(false);
		}
		else
		{
			resultText.text = "Win";
			coinsText.text = "+" + coins;
		}
	}
	
	public void Hide()
	{
		panelContainer.SetActive(false);
	}
}
