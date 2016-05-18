using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {


	public Text countText;
	public int count; 

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("BulletProgressionObject"))
		count = count + 100;
		ScoreText ();
	}

	void ScoreText(){
		countText.text = "Score: " + count.ToString ();
	}

	//GOAL: make it so that the first hit is 100 + the SUM of second and third consecutive hits. If there are no second or third consecutive hits, Score = 100;
}
