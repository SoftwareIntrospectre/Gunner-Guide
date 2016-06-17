using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript instance = null;
	public GameObject scoreTextObject;


	public int scoreValue;
	private Text scoreText;
	public int scoreMultiplier; 

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);

		scoreText = scoreTextObject.GetComponent<Text> ();
		scoreText.text = "Current Score: " + scoreValue.ToString ();
	}

	void Start(){
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

	void DisplayScore(){
		scoreText.text = "CurrentScore: " + scoreValue.ToString ();
		Debug.Log ("You got another one, Jim!"); 
	}

	public void ResetMultiplier(){
		scoreMultiplier = 0;
		Debug.Log ("Score Multiplier is reset.");
	}
}
