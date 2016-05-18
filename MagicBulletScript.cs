using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicBulletScript : MonoBehaviour {

	private int yRotation = 90;
	public float magicBulletSpeed = 1;
	public float speedOffset;
	//private static MovementPathScript singletonMPS; 
	private Vector3 input; 
	//public MovementPathScript gunnerMovement; 

	public Text countText;
	private int count; 


	void Start() {
		//gunnerMovement = GetComponent<MovementPathScript> (); 
		input = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));  
		//singletonMPS = GetComponent<MovementPathScript> (); 

	
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
			other.gameObject.SetActive (false);
	}



	//add bowling score logic Function (BOWL)
		
}

