using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScriptReloader : MonoBehaviour
{
	[SerializeField] public TMP_Text costReloader;
	[SerializeField] public TMP_Text statusReloader;
	[SerializeField] public TMP_Text buttonTMP;
	[SerializeField] public Button buttonReloader;
	[SerializeField] public int shards;
	[SerializeField] public ReloadSaveType reloadSaveType;

	public Action Reloaded { get; set; }

	public void ReloadControls()
	{
		var upgradeValue = SaveReloader.Reloader.GetReloadedValue(reloadSaveType);
		var currentShards = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.CrystalShards);

		if (upgradeValue == 10)
		{
			buttonReloader.interactable = false;
			buttonTMP.text = "MAX";
			buttonTMP.color = Color.green;
		}
		else
		{
			if (currentShards >= shards)
			{
				buttonReloader.interactable = true;
				buttonTMP.text = "UPGRADE";
				buttonTMP.color = Color.white;
			}
			else
			{
				buttonReloader.interactable = false;
				buttonTMP.text = "NO SHARDS";
				buttonTMP.color = Color.red;
			}
		}

		statusReloader.text = $"{upgradeValue}/{10}";
	}

	public void PurchaseReload()
	{
		int alreadyUpgraded = SaveReloader.Reloader.GetReloadedValue(reloadSaveType);
		SaveReloader.Reloader.SetReloadedValue(reloadSaveType, alreadyUpgraded + 1);

		int shardsNow = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.CrystalShards);
		SaveReloader.Reloader.SetReloadedValue(ReloadSaveType.CrystalShards, shardsNow - shards);

		Reloaded?.Invoke();
	}
}
