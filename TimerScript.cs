using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System; 

public class TimerScript : MonoBehaviour {
	
	private float startTime; 
	public bool timerIsStopped = false;
	public Text timerText;
	[HideInInspector] TargetScript targetScript;

	void Start(){
		targetScript = GetComponent<TargetScript> ();
	}


	void Update(){
		if ((GameObject.FindGameObjectsWithTag ("BulletProgressionObject").Length <= 0) || timerIsStopped) {
			return;
		}			
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

	public static float StartTime{
		get{return StartTime;}
	}


}
