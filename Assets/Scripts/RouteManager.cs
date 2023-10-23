using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouteManager : MonoBehaviour
{
	[SerializeField] private TMP_Text levelText;
	[SerializeField] private UIHealth uiHealth;
	[SerializeField] private UIProgressBar uiLevelProgressBar;
	[SerializeField] private PlayerMainBall player;
	[SerializeField] private UITutorialPanel tutorial;
	[SerializeField] private UICountDownPanel uiCountDownPanel;
	[SerializeField] private UIGameWinLose uiGameWinLose;
	[SerializeField] private Transform obstaclesContainer;
	[SerializeField] private ObstacleSpawner obstacleSpawner;
	private int currentLifesAmount;
	private int currentPoints;
	private int levelMaxPoints;
	private int levelMaxCoins;
	
	private void Start()
	{
		Enable();
	}
	
	public void Enable()
	{
		currentLifesAmount = PlayerSaveLoad.CurrentLifesUpgrade;
		currentPoints = 0;
		levelMaxPoints = CalculateLevelMaxPoints();
		levelMaxCoins = CalculateLevelCoins();
		
		levelText.text = "Level " + PlayerSaveLoad.CurrentLevel;
		GUIRefresh();
		
		if (PlayerSaveLoad.IsFirstTime == "y")
		{
			PlayerSaveLoad.IsFirstTime = "n";
			PlayerSaveLoad.Save();
			tutorial.TutorialEndedAction += OnTutorialEnd;
			tutorial.Play();
		}
		else
		{
			CountDown();
		}
	}
	
	private void OnTutorialEnd()
	{
		CountDown();
	}
	
	private void CountDown()
	{
		uiCountDownPanel.OnCountEndAction += OnCountDownEnd;
		uiCountDownPanel.Play();
	}
	
	private void OnCountDownEnd()
	{
		uiCountDownPanel.OnCountEndAction -= OnCountDownEnd;
		obstacleSpawner.enabled = true;
	}
	
	private void OnPlayerGotDamageHandler()
	{
		currentLifesAmount--;
		GUIRefresh();
		CheckIsLoseResult();
	}
	
	private void OnPlayerAddedCoin()
	{
		currentPoints += 2;
		GUIRefresh();
		CheckIsWinResult();
	}
	
	private void CheckIsWinResult()
	{
		if (currentPoints >= levelMaxPoints)
		{
			currentPoints = levelMaxPoints;
			GUIRefresh();
			PlayerSaveLoad.CurrentLevel++;
			PlayerSaveLoad.CurrentCoins += levelMaxCoins;
			PlayerSaveLoad.Save();
			uiGameWinLose.Show(true, levelMaxCoins);
			
			player.DisableControls();
			obstacleSpawner.Off();
		}
	}
	
	private void GUIRefresh()
	{
		uiHealth.UpdateHealth(currentLifesAmount);
		uiLevelProgressBar.UpdateProgress(currentPoints, levelMaxPoints);
	}
	
	private int CalculateLevelMaxPoints()
	{
		var currentLevel = PlayerSaveLoad.CurrentLevel;
		return (int)(currentLevel * Mathf.Log(currentLevel) + 6);
	}
	
	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}
	
	private int CalculateLevelCoins()
	{
		var level = PlayerSaveLoad.CurrentLevel;
		return (int)(Mathf.Pow(level, 1/4) * Mathf.Log(100 * level) + 53);
	}
	
	private void OnDestroy()
	{
		
	}
	
	public void ClearObstaclesContainer()
	{
		foreach (Transform child in obstaclesContainer)
		{
			Destroy(child.gameObject);
		}
	}
	
	private void CheckIsLoseResult()
	{
		if (currentLifesAmount != 0)
		{
			player.GetDamage();
			ClearObstaclesContainer();
		}
		else
		{
			uiGameWinLose.Show(false, 0);
			player.DisableControls();
			obstacleSpawner.Off();
		}
	}
}
