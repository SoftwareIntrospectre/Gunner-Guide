using UnityEngine; 
using System.Collections; 

public class TargetScript : MonoBehaviour {

	[HideInInspector]public static bool allTargetsDestroyed = false;
	[HideInInspector]public TimerScript TimerScript;
	[HideInInspector]public MovementPathScript movementPathScript;  
	private int targetsRemaining;
	public AudioSource targetHitSFX;


	void Start(){
		targetHitSFX = GetComponent<AudioSource> ();
		TimerScript = GetComponent<TimerScript> ();
		movementPathScript = GetComponent<MovementPathScript> ();  
	}
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("MagicBullet")) {
			GameManagerScript.instance.DestroyTarget (100, gameObject);  
			targetHitSFX.Play ();
		}
	}
}


