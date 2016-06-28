using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {
	
	public int scoreCount;
	public int timeBonusValue;

	private int timeBonusDifference; 


	void Start () {
		scoreCount = 0;
		timeBonusValue = 1000;
	}

	void Update(){
		TimeBonusScore ();
		Debug.Log ("Time bonus is: " + timeBonusDifference);
	}
		
	public void ScoreUpdate(){
		scoreCount += 100;
		Debug.Log ("Score increased by ." + scoreCount);
	}

	public void TimeBonusScore(){
		timeBonusDifference = timeBonusValue - ((int)Time.timeSinceLevelLoad * 10);
		//create a bonus based on time ellapsed from TimerScript.
		//time bonus = 5000 / seconds ellapsed  (round to int)
		//Math.Round (timeBonus f / 100f, 0) * 100;

	}
}
