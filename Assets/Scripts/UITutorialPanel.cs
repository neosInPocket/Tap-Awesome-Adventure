using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class UITutorialPanel : MonoBehaviour
{
	[SerializeField] GameObject mainContainer; 
	[SerializeField] private TMP_Text text;
	public Action TutorialEndedAction;
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}
	
	public void Play()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		
		mainContainer.SetActive(true);
		text.text = "Welcome to Circles!";
		Touch.onFingerDown += Edit1;
	}
	
	private void Edit1(Finger finger)
	{
		Touch.onFingerDown -= Edit1;
		Touch.onFingerDown += Edit2;
		text.text = "Control your candy by placing electromagnetic sources nearby!";
	}
	
	private void Edit2(Finger finger)
	{
		Touch.onFingerDown -= Edit2;
		Touch.onFingerDown += Edit3;
		text.text = "Be aware of spikes that sometomes appear on platforms";
	}
	
	private void Edit3(Finger finger)
	{
		Touch.onFingerDown -= Edit3;
		Touch.onFingerDown += Edit4;
		text.text = "Collect coins and buy different upgrades, such as maximum health amount";
	}
	
	private void Edit4(Finger finger)
	{
		Touch.onFingerDown -= Edit4;
		Touch.onFingerDown += Edit5;
		text.text = "Good luck!";
	}
	
	private void Edit5(Finger finger)
	{
		Touch.onFingerDown -= Edit5;
		gameObject.SetActive(false);
		TutorialEndedAction?.Invoke();
	}
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
}
