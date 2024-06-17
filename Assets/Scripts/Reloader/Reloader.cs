using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Reloader
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void EntryPoint()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
}
