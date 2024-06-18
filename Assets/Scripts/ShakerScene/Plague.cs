using UnityEngine;

public class Plague : MonoBehaviour
{
	[SerializeField] private Vector2 scales;
	[SerializeField] private Vector2 rotation;
	private float currentRotation;
	private Vector3 currentWorldRotation;
	private int direction;

	private void Start()
	{
		var scale = Random.Range(scales.x, scales.y);

		transform.localScale = Vector3.one * scale;
		currentRotation = Random.Range(rotation.x, rotation.y);

		direction = Random.Range(0, 2) == 0 ? 1 : -1;
	}

	private void Update()
	{
		currentWorldRotation.z += direction * Time.deltaTime * currentRotation;
		transform.eulerAngles = currentWorldRotation;
	}
}
