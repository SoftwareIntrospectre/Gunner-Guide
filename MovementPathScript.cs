using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MovementPathScript : MonoBehaviour {

	public EditorPathScript PathToFollow; 
	public int CurrentWayPointID = 0;
	private float speedVariable;
	public float movementSpeed;
	public float confidenceSpeed = 5;
	public float hurrySpeed; 
	private float reachDistance = 1.0f; 
	public float rotatationSpeed = 5.0f;
	public string pathName;
	private Vector3 last_position;
	private Vector3 current_position;
	public static Quaternion gunnerRotation;
	public string restartLevel;
	public string nextLevel;
	public GameObject[] targetObjects;
	float distance;
	public bool gunnerIsHurryingToFinish;
	[HideInInspector]TimerScript timerScript;
	public AudioSource speedUp;
	public AudioSource playSFX;
	[HideInInspector]public SFX_Interaction_Script sfxGOReference;
	TargetScript targetScript; 


	void Start(){
		gunnerIsHurryingToFinish = false;
		timerScript = GetComponent<TimerScript> ();
		speedUp = GetComponent<AudioSource> (); 
		sfxGOReference = GetComponent<SFX_Interaction_Script> ();
		targetScript = GetComponent<TargetScript> ();
	}
		
	void Update () {
		DistanceFunction ();
		ForwardMove ();
		PointTowards (); 

		if (gameObject.tag != "BulletProgressionObject") {
			PathNavigate ();
		}
			
		if (Input.GetKeyDown ("space"))
			SceneManager.LoadScene (restartLevel);
	}

	public void DistanceFunction(){
		distance = Vector3.Distance (PathToFollow.path_objs [CurrentWayPointID].position, transform.position); 
	}
		
	public void ForwardMove(){
			transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime * speedVariable);	 
			speedVariable = movementSpeed; 

		if (GameObject.FindGameObjectsWithTag ("BulletProgressionObject").Length == 0) {  
			GunnerHurriesToFinish (); 
		}
	}
		
	public void GunnerHurriesToFinish(){
		speedVariable = hurrySpeed;  
		gunnerIsHurryingToFinish = true;
		Debug.Log ("Run, Jim, run!");
	}
		
	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.CompareTag ("SFX_GO")) {
			movementSpeed = 0;
			sfxGOReference.enabled = false;
			SceneManager.LoadScene (restartLevel);
		}

		if (other.gameObject.CompareTag ("MagicBullet")) {
			Debug.Log ("You shot yourself.");
		}

		if(other.gameObject.CompareTag("SpeedUpGO")){
			GunnerSpeedIncrease(); 
		}
	}

	public void PointTowards(){ 
		var gunnerRotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Lerp(transform.rotation, gunnerRotation, Time.deltaTime * rotatationSpeed); 
	}

	public void PathNavigate(){
		DistanceFunction ();

		if (distance <= reachDistance) { 
			CurrentWayPointID++;
		}

		if (CurrentWayPointID >= PathToFollow.path_objs.Count) {
			CurrentWayPointID = 13;
		}
	}

	public void GunnerSpeedIncrease(){
		movementSpeed += confidenceSpeed;
		speedUp.Play ();
		if (confidenceSpeed >= movementSpeed) {
			confidenceSpeed = movementSpeed;
		}
		if (gunnerIsHurryingToFinish == true) {
			speedUp.Stop ();
		}
	}
}