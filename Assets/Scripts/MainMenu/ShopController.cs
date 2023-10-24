using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Image[] speedUpgradesStars;
	[SerializeField] private Image[] lifesUpgradesStars;
	[SerializeField] private Button SpeedButton;
	[SerializeField] private Button lifesButton;
	[SerializeField] private TMPro.TMP_Text coinsAmount;
	
	public void Refresh()
	{
		PlayerSaveLoad.Load();
		RefreshPoints();
		coinsAmount.text = PlayerSaveLoad.CurrentCoins.ToString();
		
		if (PlayerSaveLoad.CurrentCoins < 50 || PlayerSaveLoad.SpeedUpgrade == 3)
		{
			SpeedButton.interactable = false;
		}
		
		if (PlayerSaveLoad.CurrentCoins < 100 || PlayerSaveLoad.CurrentLifesUpgrade == 3)
		{
			lifesButton.interactable = false;
		}
	}
	
	public void LifesAmountUpgrade()
	{
		PlayerSaveLoad.CurrentCoins -= 100;
		PlayerSaveLoad.CurrentLifesUpgrade++;
		PlayerSaveLoad.Save();
		Refresh();
	}
	
	public void SpeedUpgrade()
	{
		PlayerSaveLoad.CurrentCoins -= 50;
		PlayerSaveLoad.SpeedUpgrade++;
		PlayerSaveLoad.Save();
		Refresh();
	}
	
	private void RefreshPoints()
	{
		foreach (var gravity in speedUpgradesStars)
		{
			gravity.color = new Color(1, 1, 1, 0);
		}
		
		for (int i = 0; i < PlayerSaveLoad.SpeedUpgrade; i++)
		{
			speedUpgradesStars[i].color = new Color(1, 1, 1, 1);
		}
		
		foreach (var life in lifesUpgradesStars)
		{
			life.color = new Color(1, 1, 1, 0);
		}
		
		for (int i = 0; i < PlayerSaveLoad.CurrentLifesUpgrade; i++)
		{
			lifesUpgradesStars[i].color = new Color(1, 1, 1, 1);
		}
	}
}
