using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript instance = null;
	public MagicBulletScript magicBulletScript;

	public GameObject scoreTextObject;

	private int scoreValue;
	private Text scoreText;




	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);

		magicBulletScript.GetComponent<MagicBulletScript> (DestroyTarget); 

		scoreText = scoreTextObject.GetComponent<Text> ();
		scoreText.text = "Score: " + scoreValue.ToString ();
		//scoreValue = scoreValue + passedValue;
	}

	public void DestroyTarget(){
		//destroy target
		//update score value
		//update score UI
	}

}
