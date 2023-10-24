using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioSource music;
	
	private void Start()
	{
		PlayerSaveLoad.Load();
		music.volume = PlayerSaveLoad.CurrentVolume;
	}
	
	public void SaveVolumeValue()
	{
		PlayerSaveLoad.CurrentVolume = music.volume;
		PlayerSaveLoad.Save();
	}
	
	public void ChangeBolume(float value)
	{
		music.volume = value;
	}
}
