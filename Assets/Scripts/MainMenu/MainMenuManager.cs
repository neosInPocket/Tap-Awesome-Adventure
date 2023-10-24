using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	private void Start()
	{
		ClearProgress();
	}
	
	public void LoadGameScene()
	{
		SceneManager.LoadScene("MainGameScene");
	}
	
	private void ClearProgress()
	{
		PlayerSaveLoad.CurrentLevel = 1;
		PlayerSaveLoad.SpeedUpgrade = 0;
		PlayerSaveLoad.CurrentCoins = 100;
		PlayerSaveLoad.CurrentLifesUpgrade = 1;
		PlayerSaveLoad.IsFirstTime = "y";
		PlayerSaveLoad.CurrentVolume = 1f;
		PlayerSaveLoad.Save();
	}
}
