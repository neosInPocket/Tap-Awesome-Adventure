using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider slider;
	
	public void Refresh()
	{
		PlayerSaveLoad.Load();
		slider.value = PlayerSaveLoad.CurrentVolume;
	}
}
