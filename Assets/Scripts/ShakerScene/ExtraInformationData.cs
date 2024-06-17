using UnityEngine;

public static class ExtraInformationData
{
	public readonly static Vector2 resolution;

	static ExtraInformationData()
	{
		resolution = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
	}

	public static Vector2 WorldPoint(Vector2 screenPoint, bool cameraRelative = false)
	{
		Vector2 worldPoint = new Vector2(
			screenPoint.x / Screen.width * resolution.x,
			screenPoint.y / Screen.height * resolution.y
		);

		if (cameraRelative)
		{
			worldPoint += (Vector2)Camera.main.transform.position;
		}

		return worldPoint;
	}
}
