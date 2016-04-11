using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	private Toggle menuToggle;
	public bool isPaused;

	void Awake(){
		menuToggle = GetComponent<Toggle> ();
	}
		
	public void MenuIsOn(){
		Time.timeScale = 0;
		isPaused = true;
		Debug.Log ("Paused");
	}

	public void MenuIsOff(){
		Time.timeScale = 1;
		isPaused = false;
		Debug.Log ("Play");
	}

	public void OnMenuStatusChange() {
		if (menuToggle.isOn && !isPaused) {
			MenuIsOn ();

		} else if (!menuToggle.isOn && isPaused)
			MenuIsOff ();
	}



}
