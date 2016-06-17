using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {
	
	public int scoreCount;

	void Start () {
		scoreCount = 0;
	}
		
	public void ScoreUpdate(){
		scoreCount += 100;
		Debug.Log ("Score increased by ." + scoreCount);
	}
}
