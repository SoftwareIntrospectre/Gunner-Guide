using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof (AudioSource))]
public class GunnerScript : MonoBehaviour {

	public Transform gunnerTransform;
	public Transform masterBulletTransform;
	public GameObject magicBulletPrefab; 
	public Vector3 magicBulletPosition; 
	public AudioSource fireBullet;

	[HideInInspector] public bool gunnerIsShootable = false;

	void Start () {
		gunnerTransform = transform;    
		fireBullet = GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) {
			MagicShoot ();
		}

		PlayFireSoundOnceOnly (); 
	} 
			
	public void MagicBulletPosition(){
		magicBulletPosition = 
			new Vector3 (masterBulletTransform.position.x +5, masterBulletTransform.position.y, masterBulletTransform.position.z * Time.deltaTime); 
	}

	public void MagicShoot(){ 
		MagicBulletPosition (); 
		Instantiate (magicBulletPrefab, masterBulletTransform.position, gunnerTransform.rotation * Quaternion.Euler(0,0,90));  
		gunnerIsShootable = true;
		Debug.Log ("Jim is now vincible.");
		fireBullet.Play ();
	}

	void PlayFireSoundOnceOnly(){ 
		if (MagicBulletScript.instance.isFired = true) {
			fireBullet.mute = false;
			Debug.Log ("There's already a bullet, Jim.");
		}
		else 
			fireBullet.mute = true;
			Debug.Log ("Fire when ready, Jim.");
	}
}
