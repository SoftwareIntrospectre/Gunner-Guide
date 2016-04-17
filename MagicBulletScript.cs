using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MagicBulletScript : MonoBehaviour {

	private int magicBUlletYRotation = 90;
	public float magicBulletSpeed = 1;
	public float speedOffset;

	private static MovementPathScript singletonMPS; 

	private Vector3 playerInput; 

	void Start() {
		playerInput = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));   
		singletonMPS = GetComponent<MovementPathScript> (); 
	}

	void Update () {
		transform.Translate (Vector3.down * magicBulletSpeed * Time.deltaTime);   
		MagicMovement ();
	}
		

	void MagicMovement(){
	/*	int[] array = { TurnRight, TurnLeft, TurnUp, TurnDown }; 
		switch (array [0]) {

		case TurnRight:
			input.x > 0;
			break;

		case TurnLeft:
			input.x < 0;
			break;

		case TurnUp:
			input.z > 0;
			break;

		case TurnDown:
			input.z < 0;
			break;

		default:
			input = 0;
			break;
		}
	*/
	
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
		Quaternion rotation = Quaternion.Euler (-magicBulletYRotation, 0, 0);
		transform.rotation = rotation;
	}

	void TurnDown(){
		Quaternion rotation = Quaternion.Euler (magicBulletYRotation, 0, 0);
		transform.rotation = rotation;
	}

	void TurnLeft(){
		transform.eulerAngles = new Vector3 (0, 0, -magicBulletYRotation);
	}

	void TurnRight(){
		transform.eulerAngles = new Vector3 (0, 0, magicBulletYRotation);
	}
		

	void OnTriggerEnter (Collider other){ 
		
		if (other.gameObject.CompareTag ("Obstacle")) {
			GunnerScript.StaticShoot ();
			Destroy (gameObject);
		}
		 
		if (other.gameObject.CompareTag ("BulletProgressionObject"))
			Destroy (other.gameObject);

		if (other.gameObject.CompareTag ("SecretBullseye"))
		Destroy (other.gameObject);
	
	}
}

