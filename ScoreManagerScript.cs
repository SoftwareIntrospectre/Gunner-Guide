using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {

	public static ScoreManagerScript scoreInstance = null;
	[HideInInspector]public int scoreCount; 
	[HideInInspector]public int timeBonusDifference;
	[HideInInspector]public MovementPathScript movementPathReference;
	[HideInInspector]public ResultsScreenManager resultsScreenReference; 
	[HideInInspector]public TimerScript timerScript;
	public int timeBonusValue;
	private int timeBonusCountdown;
	private bool timeBonusToggle;
	public bool scoreIsUpdated = false;
	public GameObject[] bulletProgressionObjectArray; 

	void Start () { 
		SetUpDefaultScore (); 
		SetUpReferences ();
	}
		
	void SetUpDefaultScore(){
		timeBonusToggle = true; 
		scoreCount = 0;
	}

	void SetUpReferences(){
		movementPathReference = GetComponent<MovementPathScript> (); 
		resultsScreenReference = GetComponent<ResultsScreenManager> (); 
	}

	void Update(){
		TimeBonusScore ();
		if (movementPathReference.gunnerIsHurryingToFinish = true) {
			Debug.Log ("Time bonus is: " + timeBonusDifference);
		}
	}

	public void ScoreUpdate(){
		scoreCount += 100;
		Debug.Log ("Score increased by ." + scoreCount);
		scoreIsUpdated = true;
	}

	public void TimeBonusScore(){
		timeBonusDifference = (timeBonusValue - ((int)Time.timeSinceLevelLoad * 100));
		if (timerScript.timerIsStopped = true) {
			timeBonusDifference = timeBonusValue;
		}
	}


}

