using UnityEngine;

public class AudioComputing : MonoBehaviour
{
	public AudioSource computing;

	public static AudioComputing Audio { get; private set; }
	public bool ComputingEnabled
	{
		get => computing.volume > 0;
		set
		{
			SaveReloader.Reloader.SetReloadedValue(ReloadSaveType.Volume, value ? 1 : 0);
			computing.volume = value ? 1 : 0;
		}
	}

	public bool SoundsActive
	{
		get => SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.Sounds) > 0;
		set => SaveReloader.Reloader.SetReloadedValue(ReloadSaveType.Sounds, value ? 1 : 0);
	}

	public void Start()
	{
		if (Audio == null)
		{
			Audio = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		computing.volume = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.Volume);
	}
}
