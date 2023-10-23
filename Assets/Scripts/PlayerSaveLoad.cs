using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveLoad : MonoBehaviour
{
    public static int CurrentLevel;
	public static int CurrentCoins;
	public static int CurrentLifesUpgrade;
	public static int SpeedUpgrade;
	public static float CurrentVolume;
	public static string IsFirstTime;
	
	public static void Save()
	{
		PlayerPrefs.SetInt("CurrentCoins", CurrentCoins);
		PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
		PlayerPrefs.SetInt("CurrentLifesUpgrade", CurrentLifesUpgrade);
		PlayerPrefs.SetInt("SpeedUpgrade", SpeedUpgrade);
		PlayerPrefs.SetFloat("CurrentVolume", CurrentVolume);
		PlayerPrefs.SetString("IsFirstTime", IsFirstTime);
	}
	
	public static void Load()
	{
		CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
		CurrentCoins = PlayerPrefs.GetInt("CurrentCoins", 100);
		CurrentLifesUpgrade = PlayerPrefs.GetInt("CurrentLifesUpgrade", 1);
		SpeedUpgrade = PlayerPrefs.GetInt("SpeedUpgrade", 0);
		IsFirstTime = PlayerPrefs.GetString("IsFirstTime", "y");
		CurrentVolume = PlayerPrefs.GetFloat("CurrentVolume", 1f);
	}
}
