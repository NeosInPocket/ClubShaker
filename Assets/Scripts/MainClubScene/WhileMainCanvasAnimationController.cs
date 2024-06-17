using UnityEngine;
using UnityEngine.SceneManagement;

public class WhileMainCanvasAnimationController : MonoBehaviour
{
	[SerializeField] public string reloadToStore;
	[SerializeField] public string reloadToSettings;
	[SerializeField] public string reloadBack;
	[SerializeField] public string reloadGame;
	[SerializeField] public string reloadScene;
	[SerializeField] public Animator canvasAnimator;

	public void ReloadToStore()
	{
		SetAnimation(reloadToStore);
	}

	public void ReloadToSettings()
	{
		SetAnimation(reloadToSettings);
	}

	public void ReloadBack()
	{
		SetAnimation(reloadBack);
	}

	public void ReloadGame()
	{
		SetAnimation(reloadGame);
	}

	public void ReloadGameAction()
	{
		SceneManager.LoadScene(reloadScene);
	}

	private void SetAnimation(string key)
	{
		canvasAnimator.SetTrigger(key);
	}
}
