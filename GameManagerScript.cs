using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript instance = null;
	public MovementPathScript movementPathScript; 
	public GameObject scoreTextObject;
	public GameObject multiplierBonusTextObject;
	public GameObject speedUITextObject;
	public GameObject gunnerSpeedTextObject;
	public int scoreValue;
	public int scoreMultiplier; 
	private Text scoreText;
	public Text multiplierBonusText;
	public Text gunnerSpeedText;
	public AudioSource emptyBarrelSFX;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		
		scoreText = scoreTextObject.GetComponent<Text> ();
		multiplierBonusText = multiplierBonusTextObject.GetComponent<Text> ();
		movementPathScript = GetComponent<MovementPathScript> ();
		gunnerSpeedText = gunnerSpeedTextObject.GetComponent<Text> ();
		emptyBarrelSFX = GetComponent<AudioSource> ();

		multiplierBonusText.text = "Multiplier x1".ToString ();
		scoreText.text = "Score: " + scoreValue.ToString ();
		gunnerSpeedText.text = "Gunner Speed: " + movementPathScript.movementSpeed.ToString();
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
		DisplayMultiplierBonus ();
		Debug.Log ("You got another one, Jim!");  
	}

	public void DisplayMultiplierBonus(){
		multiplierBonusText.text = "Multiplier x" + scoreMultiplier.ToString();
	}
}