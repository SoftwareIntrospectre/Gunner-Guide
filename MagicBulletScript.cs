using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MagicBulletScript : MonoBehaviour {

	private int yRotation = 90;
	public float magicBulletSpeed = 1;
	public string secretLevel;
	Transform bulletMovement;
	public float speedOffset;

	private static MovementPathScript singletonMPS; 

	void Update () {

		transform.Translate (Vector3.down * magicBulletSpeed * Time.deltaTime);  

		if (Input.GetKeyDown ("w")) { 
			MagicMovement1 ();
			}

		if (Input.GetKeyDown ("s")) {
			MagicMovement2 (); 
			}

		if (Input.GetKeyDown ("a")) {
			MagicMovement3 (); 
			}

		if (Input.GetKeyDown ("d")) {
			MagicMovement4 ();  
			}
		} 
		
	void MagicMovement1(){  
		Quaternion rotation = Quaternion.Euler (-yRotation, 0, 0);
		this.transform.rotation = rotation;
	}

	void MagicMovement2(){
		Quaternion rotation = Quaternion.Euler (yRotation, 0, 0);
		this.transform.rotation = rotation;
	}

	void MagicMovement3(){
		this.transform.eulerAngles = new Vector3 (0, 0, -yRotation);
	}

	void MagicMovement4(){
		this.transform.eulerAngles = new Vector3 (0, 0, yRotation);
	}
		

	void OnTriggerEnter (Collider other){ 
		
		if (other.gameObject.CompareTag ("Obstacle")) {
			GunnerScript.StaticShoot ();
			Destroy (gameObject);
		}
			
		if (other.gameObject.CompareTag ("MagnetGate"))
			Destroy (this.gameObject);
		 
		if (other.gameObject.CompareTag ("BulletProgressionObject"))
			Destroy (other.gameObject);
		//if gameObject is destroyed, increase GunnerSpeed by speedOffset


		if(other.gameObject.CompareTag("SecretBullseye"))
			SceneManager.LoadScene (secretLevel);
		}
		
}

