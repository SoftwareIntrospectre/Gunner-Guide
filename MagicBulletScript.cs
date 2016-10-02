using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicBulletScript : MonoBehaviour {
	public static MagicBulletScript instance = null;
	public GunnerScript gunnerScript;
	public MovementPathScript movementPathReference;

	private int yRotation = 90;
	private Vector3 input;  
	private ScoreManagerScript scoreManager;  

	public float magicBulletSpeed = 1;
	public float fastSpeed;
	public float slowSpeed;
	public float normalSpeed;  
	public AudioSource targetShot; 
	public bool isFired;
	public int scoreMultiplier;
	public AudioSource [] bulletSounds;

	void Awake(){
		if (instance == null) {
			instance = this;

		} else if (instance != null) {
			Destroy (gameObject);
		}
			scoreManager = GetComponent<ScoreManagerScript> ();
	}


	void Start() {
		SetUpMagicBullet ();
	}

	void SetUpMagicBullet(){
		input = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));  
		scoreManager = GetComponent<ScoreManagerScript> ();
		gunnerScript = GetComponent<GunnerScript> ();
		isFired = true;
		movementPathReference = GetComponent<MovementPathScript> (); 
		bulletSounds[0].Play (); 
	}

	void Update () {
		transform.Translate (Vector3.down * magicBulletSpeed * Time.deltaTime);   
		MagicMovement ();

		if (movementPathReference.gunnerIsHurryingToFinish == true) {
			Destroy (this.gameObject);
		} 
	}
		

	void MagicMovement(){

		if (Time.timeScale == 0) {
			return;
		}

		if (Input.GetKeyDown ("w")) { 
			TurnUp ();
		}
		if (Input.GetKeyDown ("s")) {
			TurnDown (); 
		}
		if (Input.GetKeyDown ("a")) {
			TurnLeft (); 
		}
		if (Input.GetKeyDown ("d")) {
			TurnRight ();  
		}
	}
		
	void TurnUp(){  
		Quaternion rotation = Quaternion.Euler (-yRotation, 0, 0);
		transform.rotation = rotation;
	}

	void TurnDown(){
		Quaternion rotation = Quaternion.Euler (yRotation, 0, 0);
		transform.rotation = rotation;
	}

	void TurnLeft(){
		transform.eulerAngles = new Vector3 (0, 0, -yRotation);
	}

	void TurnRight(){
		transform.eulerAngles = new Vector3 (0, 0, yRotation);
	}
		

	public void OnTriggerEnter (Collider other){ 
		if (other.gameObject.CompareTag ("Obstacle")) {
			StartCoroutine(DestroyBulletInstance ()); 
		}

		if (other.gameObject.CompareTag ("BulletProgressionObject")) {
			scoreManager.ScoreUpdate ();
		}
	}

	public IEnumerator DestroyBulletInstance(){ 
		bulletSounds [1].Play ();
		foreach (Renderer bulletRenderer in GetComponentsInChildren<Renderer>()) {
			bulletRenderer.enabled = false;
		}

		foreach (Collider bulletCollider in GetComponentsInChildren<Collider>()) {
			bulletCollider.enabled = false;
		}
		yield return new WaitForSeconds (0.55f);
		Destroy (gameObject);
		ResetMultiplier ();
		isFired = false;
		Debug.Log ("Score Multiplier is reset.");
	}
		
	public void ResetMultiplier(){
		GameManagerScript.instance.scoreMultiplier = 1;
		GameManagerScript.instance.DisplayMultiplierBonus ();
	}
}


