using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class FireWhenReadyScript : MonoBehaviour {

	public Text FireWhenReadyText; 
	public GameObject fireWhenReadyGO;
	public bool clockCanStart;

	void Start () {
		Time.timeScale = 0;
		clockCanStart = false;
	}

	void Update(){
		if (Input.GetMouseButtonDown (0))
			PlayerStartsLevel ();
	}

	void PlayerStartsLevel(){
		Time.timeScale = 1;
		Debug.Log ("Jim says he's ready.");
		Destroy (fireWhenReadyGO);
		clockCanStart = true;
	}
}
