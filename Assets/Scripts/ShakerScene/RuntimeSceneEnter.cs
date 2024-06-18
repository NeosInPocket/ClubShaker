using TMPro;
using UnityEngine;

public class RuntimeSceneEnter : MonoBehaviour
{
	[SerializeField] private ElectricDipole electricDipole;
	[SerializeField] private PointsCounter pointsCounter;
	[SerializeField] private Intermediation intermediation;
	[SerializeField] private SceneFinalizer sceneFinalizer;
	[SerializeField] private GameObject skipObject;
	[SerializeField] private TMP_Text skipObjectText;

	private void Start()
	{
		pointsCounter.InitializeCounter();
		pointsCounter.AllGrabsCompleted += OnAllGrabsCompleted;

		if (SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.Intermediation) == 1)
		{
			SaveReloader.Reloader.SetReloadedValue(ReloadSaveType.Intermediation, 0);
			intermediation.EnableIntermediation(IntermediationCallback);
		}
		else
		{
			IntermediationCallback();
		}
	}

	public void IntermediationCallback()
	{
		skipObjectText.text = "level " + SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.PlayerLevel).ToString();
		skipObject.SetActive(true);
	}

	public void SkipObject()
	{
		skipObject.SetActive(false);
		ReloadGameProcess();
	}

	public void ReloadGameProcess()
	{
		electricDipole.SetDipole(true);
		electricDipole.DipolePopped += DipolePopped;
		electricDipole.DipoleScored += DipoleScored;
	}

	public void DipolePopped()
	{
		pointsCounter.AllGrabsCompleted -= OnAllGrabsCompleted;
		electricDipole.DipolePopped -= DipolePopped;
		electricDipole.DipoleScored -= DipoleScored;
		electricDipole.SetDipole(false);

		sceneFinalizer.winReload = false;
		sceneFinalizer.shards = 0;
		sceneFinalizer.level = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.PlayerLevel);
		sceneFinalizer.Finale();
	}

	public void DipoleScored()
	{
		pointsCounter.IncrementGrabAmount();
	}

	private void OnAllGrabsCompleted()
	{
		pointsCounter.AllGrabsCompleted -= OnAllGrabsCompleted;
		electricDipole.DipolePopped -= DipolePopped;
		electricDipole.DipoleScored -= DipoleScored;
		electricDipole.SetDipole(false);

		sceneFinalizer.winReload = true;
		sceneFinalizer.shards = pointsCounter.allLevelShards;
		sceneFinalizer.level = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.PlayerLevel) - 1;
		sceneFinalizer.Finale();
	}

	private void OnDestroy()
	{
		electricDipole.DipolePopped -= DipolePopped;
		electricDipole.DipoleScored -= DipoleScored;
	}
}
