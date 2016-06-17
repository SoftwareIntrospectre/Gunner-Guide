using UnityEngine; 
using System.Collections; 

public class TargetScript : MonoBehaviour {
	
	public AudioSource targetHit;
	public int value;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("MagicBullet")) {
			GameManagerScript.instance.DestroyTarget (value, gameObject);  

			AudioSource source = GetComponent<AudioSource> ();
			source.Play ();
		}
	}
}

