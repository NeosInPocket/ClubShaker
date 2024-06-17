using Unity.VisualScripting;
using UnityEngine;

public class SaveReloader : MonoBehaviour
{
	[SerializeField] private bool reloadNewSaves;
	[SerializeField] private int[] defaultReloads;
	[SerializeField] private ReloadSaveType[] allTypes;
	private int[] reloadValues;

	public static SaveReloader Reloader { get; private set; }

	public void Awake()
	{
		StartReload();
	}

	public void StartReload()
	{
		if (Reloader != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Reloader = this;
			DontDestroyOnLoad(gameObject);
		}

		if (reloadNewSaves)
		{
			ReloadDefaults();
		}
		else
		{
			ReloadExisting();
		}
	}

	private void ReloadDefaults()
	{
		reloadValues = defaultReloads;
		SerializeReload();
	}

	private void ReloadExisting()
	{
		for (int i = 0; i < reloadValues.Length; i++)
		{
			reloadValues[i] = PlayerPrefs.GetInt(allTypes[i].ToString());
		}
	}

	public void SerializeReload()
	{
		for (int i = 0; i < reloadValues.Length; i++)
		{
			PlayerPrefs.SetInt(allTypes[i].ToString(), reloadValues[i]);
		}

		PlayerPrefs.Save();
	}

	public int GetReloadedValue(ReloadSaveType reloadSaveType)
	{
		var returnValue = reloadValues[(int)reloadSaveType];
		return returnValue;
	}

	public void SetReloadedValue(ReloadSaveType type, int value)
	{
		reloadValues[(int)type] = value;
		SerializeReload();
	}
}

public enum ReloadSaveType
{
	PlayerLevel,
	CrystalShards,
	Intermediation,
	HoleUpgade,
	FistUpgrade,
	Volume,
	Sounds
}
