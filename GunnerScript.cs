using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GunnerScript : MonoBehaviour {

	//private static GunnerScript singleton;

	public Transform gunnerTransform;
	public Transform masterBulletTransform;
	public GameObject magicBulletPrefab; 
	public Vector3 magicBulletPosition; 

	/*public Text scoreText; 
	public int score;  */

	void Start () {
		//singleton = this;
		gunnerTransform = transform;  
		MagicShoot ();    
		//score = 0;
		//UpdateScore ();
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) 
			MagicShoot ();
	} 
			
	public void MagicBulletPosition(){
		magicBulletPosition = 
			new Vector3 (masterBulletTransform.position.x +5, masterBulletTransform.position.y, masterBulletTransform.position.z * Time.deltaTime); 
	}


	void OnTriggerEnter(Collider other){ 
		if (gameObject.CompareTag ("BulletProgressionObject")) {
			//score = score + 10;
			//UpdateScore();
		}
	}
		

	/*public static void StaticShoot() {
		singleton.MagicShoot (); 
	}*/

	public void MagicShoot(){ 
		
		MagicBulletPosition (); 
		Instantiate (magicBulletPrefab, masterBulletTransform.position, gunnerTransform.rotation * Quaternion.Euler(0,0,90));  
	}

	/*public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score.ToString ();
	}*/
}
