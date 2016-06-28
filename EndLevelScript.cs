using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {

	public TimerScript timer; 
	public Transform[] childTargetTransforms;

	void Start(){
		timer = GetComponent<TimerScript> (); 
	}

	void Update(){
		if (childTargetTransforms == null)
			timer.StopTimer ();
	}

}
