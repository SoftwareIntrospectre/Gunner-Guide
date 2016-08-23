using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	
	private float startTime;
	public bool timerIsStopped = false;
	public Text timerText;
	[HideInInspector]public ScoreManagerScript scoreManager;

	void Start(){
		scoreManager = GetComponent<ScoreManagerScript> ();
	}

	void Update(){

		if (timerIsStopped)
			return;

		ActiveTimer ();
	}
		

	public void ActiveTimer(){
		float timeDifference = Time.timeSinceLevelLoad - startTime;

		string minutes = ((int)timeDifference / 60).ToString ();
		string seconds = (timeDifference % 60).ToString ("f2");

		this.timerText.text = "Time: " + minutes + ":0" + seconds;

		if (timeDifference % 60 >= 10)
			this.timerText.text = "Time: " + minutes + ":" + seconds;
		}


	public void StopTimer(){ 
		timerIsStopped = true;
		Time.timeScale = 0;
		timerText.color = Color.yellow;
	}
}
