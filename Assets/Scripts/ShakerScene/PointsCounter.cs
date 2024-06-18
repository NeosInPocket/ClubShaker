using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
	[SerializeField] private TMP_Text shardsCount;
	[SerializeField] private TMP_Text levelCount;
	[SerializeField] private TMP_Text progresssCount;
	[SerializeField] private Image progressCountFill;
	[HideInInspector] public int allLevelShards;
	private int currentGrabs;
	private int allGrabs;

	public Action AllGrabsCompleted;

	private void Start()
	{
		InitializeCounter();
	}

	public void ReloadCounterControls()
	{
		progresssCount.text = currentGrabs + "/" + allGrabs;
		progressCountFill.fillAmount = (float)currentGrabs / (float)allGrabs;
	}

	public void IncrementGrabAmount()
	{
		currentGrabs++;
		ReloadCounterControls();

		if (currentGrabs >= allGrabs)
		{
			var currentLevel = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.PlayerLevel);
			var currentShards = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.CrystalShards);

			SaveReloader.Reloader.SetReloadedValue(ReloadSaveType.PlayerLevel, currentLevel + 1);
			SaveReloader.Reloader.SetReloadedValue(ReloadSaveType.CrystalShards, currentShards + allLevelShards);
			AllGrabsCompleted?.Invoke();
		}
	}

	public void InitializeCounter()
	{
		var playerLevel = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.PlayerLevel);
		allLevelShards = (int)(10 * Mathf.Log(playerLevel * playerLevel) + 50);
		allGrabs = (int)(2 * Mathf.Log(playerLevel * playerLevel) + 3);

		shardsCount.text = allLevelShards.ToString();
		levelCount.text = "level " + playerLevel.ToString();
		progresssCount.text = "0/" + allGrabs;
		progressCountFill.fillAmount = 0f;
	}
}
