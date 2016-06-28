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
	//when the game loads, the game is paused by default
	//have a GUI that says "Fire When Ready". 
	//When the player Fires, remove "Fire When Ready" GUI and unpause the game
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
