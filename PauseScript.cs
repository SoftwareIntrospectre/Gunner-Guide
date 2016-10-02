using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	public TimerScript timerScript;
	public Text pausedText;
	public GameObject pausedPanel;
	public FireWhenReadyScript fireWhenReadyScript; 
	private Toggle menuToggle;
	[HideInInspector] GunnerScript gunnerScript;

	void Awake(){
		menuToggle = GetComponent<Toggle> ();
		timerScript = GetComponent<TimerScript> ();
		fireWhenReadyScript = GetComponent<FireWhenReadyScript> ();
		gunnerScript = GetComponent<GunnerScript> (); 
		pausedPanel.SetActive (false);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Paused_MenuIsOn ();
			} else { 
				Paused_MenuIsOff (); 
			}
		}
	}

	public void OnMenuStatusChange() {
		if (menuToggle.isOn) {
			Paused_MenuIsOn ();

		} /*else if (!menuToggle.isOn)
			Paused_MenuIsOff ();*/
	}
		
	public void Paused_MenuIsOn(){
		Time.timeScale = 0;
		AudioListener.volume = 0;
		pausedPanel.SetActive (true);
		Debug.Log ("Paused");
	}

	public void Paused_MenuIsOff(){
		Time.timeScale = 1;
		AudioListener.volume = 1;
		pausedPanel.SetActive (false);
		Debug.Log ("Play");
	}
}
