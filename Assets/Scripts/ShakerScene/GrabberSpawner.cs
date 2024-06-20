using UnityEngine;

public class GrabberSpawner : MonoBehaviour
{
	[SerializeField] private Grabber firstGrabber;
	[SerializeField] private Plague plagueTemplate;
	[SerializeField] private Grabber grabberTemplate;
	[SerializeField] private Vector2 spawnDistances;
	[SerializeField] private float xRates;
	[SerializeField] ElectricDipole dipole;
	[HideInInspector] private Grabber lastGrabber;
	Vector2 resolution;

	private void Start()
	{
		resolution = ExtraInformationData.GetExtraInformation();
		lastGrabber = firstGrabber;
	}

	private void Update()
	{
		if (dipole.transform.position.y + 2 * resolution.y > lastGrabber.transform.position.y)
		{
			SpawnGrabber();
		}
	}

	public void SpawnGrabber()
	{
		Vector2 grabberPosition = new Vector2();
		float xRate = 2 * resolution.x * xRates;
		grabberPosition.x = Random.Range(-resolution.x + xRate, resolution.x - xRate);
		grabberPosition.y = lastGrabber.transform.position.y + Random.Range(spawnDistances.x, spawnDistances.y);
		var preLastGrabber = lastGrabber;

		lastGrabber = Instantiate(grabberTemplate, grabberPosition, Quaternion.identity, transform);
		Vector2 plaguePosition = new Vector2();
		plaguePosition.x = Random.Range(-resolution.x + xRate, resolution.x - xRate);
		plaguePosition.y = (lastGrabber.transform.position.y + preLastGrabber.transform.position.y) / 2;

		var plague = Instantiate(plagueTemplate, plaguePosition, Quaternion.identity, transform);
	}
}
