using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;
using Cinemachine;
using System;

public class ElectricDipole : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera vCam;
	[SerializeField] private Transform[] pivots;
	[SerializeField] private ElectricBall[] electricBalls;
	[SerializeField] private GameObject[] orbBacks;
	[SerializeField] private SpriteRenderer[] renderers;
	[SerializeField] private DipoleUpgrades dipoleUpgrades;
	[SerializeField] private ParticleSystem bridgeSystem;
	private int currentPivotIndex = 0;
	private Transform currentPivot => pivots[currentPivotIndex];
	private Transform currentBall => electricBalls[currentPivotIndex].transform;
	private float currentRotation;
	private int direction = 1;
	private Vector3 currentWorldRotation;
	private bool restricted = false;

	public Action DipolePopped { get; set; }
	public Action DipoleScored { get; set; }

	private void Start()
	{
		currentRotation = dipoleUpgrades.Rotation;
	}

	public void SetDipole(bool value)
	{
		if (value)
		{
			Touch.onFingerDown += OnMobileActionsPress;
		}
		else
		{
			Touch.onFingerDown -= OnMobileActionsPress;
		}
	}

	private void OnMobileActionsPress(Finger finger)
	{
		TogglePivot();

		var circleCast = Physics2D.OverlapCircleAll(currentBall.transform.position, renderers[0].size.x / 2);

		Grabber grabber = null;

		for (int i = 0; i < circleCast.Length; i++)
		{
			if (circleCast[i].GetComponent<Grabber>() != null)
			{
				grabber = circleCast[i].GetComponent<Grabber>();
				break;
			}
		}

		if (grabber != null)
		{
			grabber.Complete();
			DipoleScored?.Invoke();
		}
	}

	public void TogglePivot()
	{
		currentPivotIndex = 1 - currentPivotIndex;
		currentPivot.position = currentBall.position;
		currentWorldRotation = currentPivot.eulerAngles;
		vCam.Follow = currentBall;

		transform.SetParent(currentPivot);
		direction *= 1;
	}

	public void OnElectricBallTriggerEnter()
	{
		DipolePopped?.Invoke();
		restricted = true;

		electricBalls[0].Pop();
		electricBalls[1].Pop();
		renderers[0].enabled = false;
		renderers[1].enabled = false;
		orbBacks[0].SetActive(false);
		orbBacks[1].SetActive(false);

		bridgeSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
		vCam.Follow = null;
	}

	public void Update()
	{
		if (restricted) return;

		currentWorldRotation.z += direction * currentRotation * Time.deltaTime;
		currentPivot.eulerAngles = currentWorldRotation;
	}

	public void OnDestroy()
	{
		Touch.onFingerDown -= OnMobileActionsPress;
	}
}
