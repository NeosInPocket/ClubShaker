using UnityEngine;

public class SettingsReloader : MonoBehaviour
{
	[SerializeField] public GameObject volumeTip;
	[SerializeField] public GameObject soundsTip;

	public void Start()
	{
		ReloadSettingsControls();
	}

	public void SetVolumeTipTrigger()
	{
		AudioComputing.Audio.ComputingEnabled = !AudioComputing.Audio.ComputingEnabled;
		ReloadSettingsControls();
	}

	public void SetSoundsTipTrigger()
	{
		AudioComputing.Audio.SoundsActive = !AudioComputing.Audio.SoundsActive;
		ReloadSettingsControls();
	}

	public void ReloadSettingsControls()
	{
		volumeTip.SetActive(AudioComputing.Audio.ComputingEnabled);
		soundsTip.SetActive(AudioComputing.Audio.SoundsActive);
	}
}
