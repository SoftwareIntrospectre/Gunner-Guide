using UnityEngine;
using System.Collections; 

public class TargetScript : MonoBehaviour {

	public AudioSource targetHit;

	void Start(){
		targetHit = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("MagicBullet")) {
			targetHit.Play ();
			Destroy (gameObject);
		}
	}
}
