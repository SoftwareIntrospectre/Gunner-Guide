﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicBulletScript : MonoBehaviour {

	private int yRotation = 90;
	private Vector3 input;  
	private ScoreManagerScript scoreManager; 

	public float magicBulletSpeed = 1;
	public float fastSpeed;
	public float slowSpeed;
	public float normalSpeed;  
	public AudioSource targetShot; 


	void Start() {

		input = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));  
		scoreManager = GetComponent<ScoreManagerScript> ();
		targetShot = GetComponent<AudioSource> ();
	}

	void Update () {
		transform.Translate (Vector3.down * magicBulletSpeed * Time.deltaTime);   
		MagicMovement ();
	}
		

	void MagicMovement(){
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
		

	void OnTriggerEnter (Collider other){ 
		if (other.gameObject.CompareTag ("Obstacle")) 
			this.gameObject.SetActive (false);

		if (other.gameObject.CompareTag ("BulletProgressionObject"))
			//DestroyTarget ();
			targetShot.Play ();
			scoreManager.ScoreUpdate ();

		if (other.gameObject.CompareTag ("FastGate"))
			magicBulletSpeed = magicBulletSpeed * fastSpeed;

		if (other.gameObject.CompareTag ("SlowGate")) 
			magicBulletSpeed = slowSpeed; 

		if (other.gameObject.CompareTag ("NormalSpeedGate"))
			magicBulletSpeed = normalSpeed;
	}

	public void DestroyTarget(int passedValue, GameObject passedObject){
		passedObject.GetComponent<Renderer> ().enabled = false;
		Destroy (passedObject, 1.0f);
	}
}

