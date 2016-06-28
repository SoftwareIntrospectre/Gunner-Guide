using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript instance = null;
	public GameObject scoreTextObject;
	public GameObject consecutiveBonusTextObject;
	public GameObject speedUITextObject;
	public int scoreValue;
	public int scoreMultiplier; 
	private Text scoreText;
	public Text consecutiveBonusText;
	public Text speedUIText;
	public string Fast;  
	public string Slow; 
	public string Normal; 


	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);

		scoreText = scoreTextObject.GetComponent<Text> ();
		consecutiveBonusText = consecutiveBonusTextObject.GetComponent<Text> ();
		speedUIText = speedUITextObject.GetComponent<Text> ();
		scoreText.text = "Score: " + scoreValue.ToString ();
		scoreMultiplier = 1;
	}

	public void DestroyTarget(int passedValue, GameObject passedObject){
		passedObject.GetComponent<Renderer> ().enabled = false; 
		passedObject.GetComponent<Collider> ().enabled = false; 
		Destroy (passedObject, 0.4f);
		scoreValue = scoreValue + (passedValue * scoreMultiplier);
		scoreMultiplier++;
		DisplayScore ();
	}
		
	public void DisplayScore(){
		scoreText.text = "Score: " + scoreValue.ToString ();
		DisplayConsecutiveBonus ();
		Debug.Log ("You got another one, Jim!"); 
	}

	public void DisplayConsecutiveBonus(){
		consecutiveBonusText.text = "Multiplier x " + scoreMultiplier.ToString();
	}

	//refactor into cleaner code later
	public void DisplayFastText(){
		speedUIText.text = "Speed: " + Fast;
	}

	public void DisplaySlowText(){
		speedUIText.text = "Speed: " + Slow;
	}

	public void DisplayNormalText(){
		speedUIText.text = "Speed: " + Normal;
	}
}