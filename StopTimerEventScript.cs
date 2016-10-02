using UnityEngine;
using System.Collections;

public class StopTimerEventScript : MonoBehaviour {

	//this is practice for delegates and events

	public delegate void TimerHandler();

	public static event TimerHandler onTimerActive;

	public static void ActiveTimer(){ 
		if (onTimerActive != null)
			ActiveTimer ();
	}
}
