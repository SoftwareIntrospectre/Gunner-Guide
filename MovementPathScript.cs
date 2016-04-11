using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovementPathScript : MonoBehaviour {

	public GunnerPathScript PathToFollow; 

	public int CurrentWayPointID = 0;
	private float speedVariable;
	public float gunnerSpeed;
	public float hurrySpeed; 
	private float reachDistance = 1.0f;
	public float rotatationSpeed = 5.0f;
	public string pathName;

	public static Quaternion gunnerRotation;

	public string nextLevel;
	public string restartLevel;

	private Vector3 last_position;
	private Vector3 current_position; 

	public GameObject progressionObjectParent;



	void Start () {
		last_position = transform.position; 
	}

	void Update () {

		float distance = Vector3.Distance (PathToFollow.path_objs [CurrentWayPointID].position, transform.position); 
		GunnerMove ();

		PointTowards (); 

		if (distance <= reachDistance) {
			CurrentWayPointID++;
		}

		if (CurrentWayPointID >= PathToFollow.path_objs.Count) {
			CurrentWayPointID = 13;
		}
	}
		
		void GunnerMove(){
			transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime * speedVariable);	 
			speedVariable = gunnerSpeed; 

		if (GameObject.FindGameObjectsWithTag ("BulletProgressionObject").Length == 0) {  
			HurryUp ();
		}
	}

	void HurryUp(){
		speedVariable = hurrySpeed;  
	}
		


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("BulletProgressionObject"))
			Destroy (other.gameObject);

		if (other.gameObject.CompareTag ("LaserGate") || Input.GetKey(KeyCode.Space))
			SceneManager.LoadScene (restartLevel);

		if (other.gameObject.CompareTag ("NextLevel"))
			SceneManager.LoadScene (nextLevel);
	}

	public void PointTowards(){ 
		var gunnerRotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Lerp(transform.rotation, gunnerRotation, Time.deltaTime * rotatationSpeed); 
	}
}

