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
	public bool isDead;
	[HideInInspector]TimerScript timerScript;
	[HideInInspector]public SFX_Interaction_Script sfxGOReference;
	public AudioSource[] gunnerSounds;
	private TargetScript targetScript; 
	public GunnerScript gunnerScript; 


	void Start(){
		gunnerIsHurryingToFinish = false;
		isDead = !true;
		timerScript = GetComponent<TimerScript> ();
		sfxGOReference = GetComponent<SFX_Interaction_Script> ();
		targetScript = GetComponent<TargetScript> ();
		gunnerScript = GetComponent<GunnerScript> ();
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
				isDead = true;
				StartCoroutine (GunnerDeath ());
			} 

		if (other.gameObject.CompareTag ("Goal")) {
			StartCoroutine (GoalReached ());
		}


		if (other.gameObject.CompareTag ("MagicBullet")) {
			Debug.Log ("You shot yourself.");
			StartCoroutine (GunnerDeath ());
			MagicBulletScript.instance.bulletSounds [1].mute = true;
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
		gunnerSounds[0].Play ();
		if (confidenceSpeed >= movementSpeed) {
			confidenceSpeed = movementSpeed;
		}
		if (gunnerIsHurryingToFinish == true) {
			gunnerSounds [0].mute = true;
		}
	}

	public IEnumerator GunnerDeath(){
		movementSpeed = 0;
		MagicBulletScript.instance.DestroyBulletInstance ();
		foreach (Renderer gunnerRenderer in GetComponentsInChildren<Renderer>()) {
			gunnerRenderer.enabled = false;
		}
		gunnerSounds[1].Play (); 
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (restartLevel);
	}

	public IEnumerator GoalReached(){
		movementSpeed = 0;
		gunnerSounds [2].Play ();
		yield return new WaitForSeconds (1.2f);
		SceneManager.LoadScene (nextLevel);
	}
}