using UnityEngine;

public class StoreReloader : MonoBehaviour
{
	[SerializeField] public UpgradeScriptReloader upgradeScriptReloader1;
	[SerializeField] public UpgradeScriptReloader upgradeScriptReloader2;
	[SerializeField] public GoodsReloader goodsReloader;

	private void Start()
	{
		upgradeScriptReloader1.Reloaded += OnReloaded;
		upgradeScriptReloader2.Reloaded += OnReloaded;

		upgradeScriptReloader1.ReloadControls();
		upgradeScriptReloader2.ReloadControls();
	}

	public void OnReloaded()
	{
		upgradeScriptReloader1.ReloadControls();
		upgradeScriptReloader2.ReloadControls();
		goodsReloader.ReloadAllGoods();
	}

	public void OnDestroy()
	{
		upgradeScriptReloader1.Reloaded -= OnReloaded;
		upgradeScriptReloader2.Reloaded -= OnReloaded;
	}
}
