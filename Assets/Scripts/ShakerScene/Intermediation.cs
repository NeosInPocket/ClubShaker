using System;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;
using TMPro;

public class Intermediation : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private TMP_Text actionHolder;
	private readonly string[] actions =
	{
		"welcome to Plimo Blocks, wanderer",
		"let's start by learning how to control your magic spheres",
		"one of the spheres is constantly rotating around the other, tap on the screen to make the second sphere start rotating",
		"direct your spheres into magical orbs to activate them",
		"activate the required number of orbs to complete the level",
		"be careful, there may be poisonous thorns on your way that you need to avoid",
		"good luck, wanderer"
	};
	[HideInInspector] public int currentAction = 0;

	public Action Callback;

	public void EnableIntermediation(Action callback)
	{
		gameObject.SetActive(true);
		Callback = callback;
		Touch.onFingerDown += OnFingerDownNextAction;

		actionHolder.text = actions[currentAction];
		currentAction++;
	}

	private void OnFingerDownNextAction(Finger finger)
	{
		try
		{
			actionHolder.text = actions[currentAction];
			currentAction++;
			animator.SetTrigger("reloadState");
		}
		catch (Exception e)
		{
			Callback();
			Touch.onFingerDown -= OnFingerDownNextAction;
			gameObject.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnFingerDownNextAction;
	}
}
