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
	private bool hasPlayed = false;
	public MovementPathScript movementPathReference;
	public AudioSource emptyGunSFX;

	void Start () {
		movementPathReference = GetComponent<MovementPathScript> ();
		gunnerTransform = transform;    
		emptyGunSFX = GetComponent<AudioSource> (); 
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine(MagicShoot());
			if (movementPathReference.gunnerIsHurryingToFinish = true) {
				return;
			} 
		}
	} 
			
	public void MagicBulletPosition(){
		hasPlayed = true;
		magicBulletPosition = 
			new Vector3 (masterBulletTransform.position.x +5, masterBulletTransform.position.y, masterBulletTransform.position.z * Time.deltaTime); 
	}

	public IEnumerator MagicShoot(){ 
		if (MagicBulletScript.instance != null) {
			emptyGunSFX.Play ();
			yield return null;
		} 
			MagicBulletPosition (); 
			Instantiate (magicBulletPrefab, masterBulletTransform.position, gunnerTransform.rotation * Quaternion.Euler (0, 0, 90));  
		}
}

