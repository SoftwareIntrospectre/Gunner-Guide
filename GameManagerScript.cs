using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript instance = null;
	public GameObject scoreTextObject;
	public GameObject consecutiveBonusTextObject;

	public int scoreValue;
	private Text scoreText;
	public Text consecutiveBonusText;
	public int scoreMultiplier; 

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);

		scoreText = scoreTextObject.GetComponent<Text> ();
		consecutiveBonusText = consecutiveBonusTextObject.GetComponent<Text> ();
		scoreText.text = "Current Score: " + scoreValue.ToString ();
		scoreMultiplier = 0;
	}

	public void DestroyTarget(int passedValue, GameObject passedObject){
		passedObject.GetComponent<Renderer> ().enabled = false; 
		passedObject.GetComponent<Collider> ().enabled = false; 
		Destroy (passedObject, 0.5f); 
		scoreMultiplier++;
		scoreValue = scoreValue + (passedValue * scoreMultiplier);
		DisplayScore ();
	}

	public void DisplayScore(){
		scoreText.text = "Score: " + scoreValue.ToString ();
		DisplayConsecutiveBonus ();
		Debug.Log ("You got another one, Jim!"); 
	}

	public void DisplayConsecutiveBonus(){
		consecutiveBonusText.text = "Hit x" + scoreMultiplier.ToString();
	}
}