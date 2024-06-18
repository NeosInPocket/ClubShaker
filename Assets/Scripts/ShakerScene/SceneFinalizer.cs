using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFinalizer : MonoBehaviour
{
	[SerializeField] private TMP_Text completedTask;
	[SerializeField] private TMP_Text shardsTask;
	[SerializeField] private TMP_Text nextActionText;
	[SerializeField] private string mainMenuSceneDesc;
	[SerializeField] private string mainSceneDesc;


	[HideInInspector] public bool winReload;
	[HideInInspector] public int shards;
	[HideInInspector] public int level;

	public void Finale()
	{
		gameObject.SetActive(true);

		if (winReload)
		{
			completedTask.text = "level " + level + " completed";
			shardsTask.text = shards.ToString();
			nextActionText.text = "NEXT LEVEL";
		}
		else
		{
			completedTask.text = "level " + level + " failed";
			shardsTask.text = 0.ToString();
			nextActionText.text = "try again";
		}

	}

	public void MenuFinale()
	{
		SceneManager.LoadScene(mainMenuSceneDesc);
	}

	public void NextFinale()
	{
		SceneManager.LoadScene(mainSceneDesc);
	}
}
