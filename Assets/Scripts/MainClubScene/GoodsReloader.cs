using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoodsReloader : MonoBehaviour
{
	[SerializeField] private List<TMP_Text> shardsInstances;
	[SerializeField] private List<TMP_Text> levelInstances;

	public void Start()
	{
		ReloadAllGoods();
	}

	public void ReloadAllGoods()
	{
		var shards = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.CrystalShards);
		var levels = SaveReloader.Reloader.GetReloadedValue(ReloadSaveType.PlayerLevel);
		shardsInstances.ForEach(s => s.text = shards.ToString());
		levelInstances.ForEach(s => s.text = levels.ToString());
	}
}
