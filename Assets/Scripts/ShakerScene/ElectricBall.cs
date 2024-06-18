using UnityEngine;

public class ElectricBall : MonoBehaviour
{
	[SerializeField] private GameObject popEffect;
	[SerializeField] private ElectricDipole electricBall;

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "Left" || collider.name == "Right")
			electricBall.OnElectricBallTriggerEnter();

		if (collider.TryGetComponent<Plague>(out Plague plague))
		{
			electricBall.OnElectricBallTriggerEnter();
		}
	}

	public void Pop()
	{
		popEffect.SetActive(true);
	}
}
