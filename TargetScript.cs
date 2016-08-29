using UnityEngine; 
using System.Collections; 

public class TargetScript : MonoBehaviour {

	[HideInInspector]public static bool allTargetsDestroyed = false;
	[HideInInspector]public TimerScript TimerScript;
	[HideInInspector]public MovementPathScript movementPathScript;  
	private int targetsRemaining;
	public AudioSource targetHitSFX;
	public GameObject[] targetCount; 


	void Start(){
		targetHitSFX = GetComponent<AudioSource> ();
		TimerScript = GetComponent<TimerScript> ();
		movementPathScript = GetComponent<MovementPathScript> ();  
		targetCount = GameObject.FindGameObjectsWithTag ("BulletProgressionObject");
		targetsRemaining = targetCount.Length;
	}

	void Update(){
		//SpeedGunnerUpForEveryTargetDestroyed (); 
	}
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("MagicBullet")) {
			GameManagerScript.instance.DestroyTarget (100, gameObject);  
			targetHitSFX.Play ();
		}
	}

	/*void SpeedGunnerUpForEveryTargetDestroyed(){ 
		foreach (GameObject target in targetCount) {
			movementPathScript.movementSpeed -= movementPathScript.confidenceSpeed; 
			if (targetCount[target]--){
				movementPathScript.confidenceSpeed++;  


				}//end of target decrease condition
			} //end of foreach loop body
	} // end of SpeedGunnerUpForEveryTargetDestroyed() function

*/
}


