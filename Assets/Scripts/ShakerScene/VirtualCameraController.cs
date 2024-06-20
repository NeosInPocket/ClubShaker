using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class VirtualCameraController : CinemachineExtension
{
	[SerializeField] private SpriteRenderer left;
	[SerializeField] private SpriteRenderer right;

	private void Start()
	{
		var resolution = ExtraInformationData.GetExtraInformation();
		left.transform.localPosition = new Vector2(-resolution.x - 0.5f, 0);
		right.transform.localPosition = new Vector2(resolution.x + 0.5f, 0);

		left.size = new Vector2(1, resolution.y * 2);
		right.size = new Vector2(1, resolution.y * 2);
	}

	protected override void PostPipelineStageCallback(
		CinemachineVirtualCameraBase virtualCamera,
		CinemachineCore.Stage stage, ref CameraState cameraState, float deltaTime)
	{
		if (stage == CinemachineCore.Stage.Body)
		{
			var virtualCameraPosition = cameraState.RawPosition;
			virtualCameraPosition.x = 0;
			cameraState.RawPosition = virtualCameraPosition;
		}
	}
}