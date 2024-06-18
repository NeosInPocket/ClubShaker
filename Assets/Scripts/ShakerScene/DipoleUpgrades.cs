using UnityEngine;

[CreateAssetMenu(menuName = "DipoleUpgrades", fileName = "DipoleUpgrades")]
public class DipoleUpgrades : ScriptableObject
{
	[SerializeField] private int[] rotation;
	[SerializeField] private float[] grabberSize;

	public int Rotation => rotation[SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.FistUpgrade)];
	public float GrabberSize => rotation[SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.HoleUpgade)];
}
