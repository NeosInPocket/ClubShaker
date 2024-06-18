using UnityEngine;

public class Grabber : MonoBehaviour
{
	[SerializeField] private new Collider2D collider;
	[SerializeField] ParticleSystem grabberEffect;
	[SerializeField] Vector2 sizes;
	[SerializeField] GameObject completeEffect;

	private void Start()
	{
		var randomScale = Random.Range(sizes.x, sizes.y);
		transform.localScale = Vector3.one * randomScale;
	}

	public void Complete()
	{
		var main = grabberEffect.main;
		main.startColor = Color.green;
		collider.enabled = false;
		completeEffect.SetActive(true);
	}
}
