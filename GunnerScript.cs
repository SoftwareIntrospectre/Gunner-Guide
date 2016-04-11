using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GunnerScript : MonoBehaviour {

	private static GunnerScript singleton;

	public Transform gunnerTransform;
	public GameObject masterBullet; 
	public GameObject magicBullet; 
	public Vector3 magicBulletPosition; 
	bool isFired;

	void Start () {
		singleton = this;
		gunnerTransform = transform;
		MagicShoot ();  

	}
			
	public void MagicBulletPosition(){
		magicBulletPosition = 
			new Vector3 (gunnerTransform.position.x + 5, gunnerTransform.position.y, gunnerTransform.position.z + 1 * Time.deltaTime); 
	}
		

	public static void StaticShoot() {
		singleton.MagicShoot (); 
	}

	public void MagicShoot(){ 
		
		MagicBulletPosition (); 
		Instantiate (magicBullet, masterBullet.transform.position, gunnerTransform.rotation * Quaternion.Euler(90,0,90));  
	}
}
