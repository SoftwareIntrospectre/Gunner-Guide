using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovementPathScript : MonoBehaviour {

	public GunnerPathScript PathToFollow; 

	public int CurrentWayPointID = 0;
	public float gunnerSpeed;
	private float reachDistance = 1.0f;
	public float rotatationSpeed = 5.0f;
	public string pathName;

	public static Quaternion gunnerRotation;

	public string nextLevel;
	public string restartLevel;

	private Vector3 last_position;
	private Vector3 current_position; 

	public LevelManager levelManager; 



	void Start () {
		//pathToFollow = GameObject.Find (pathName).GetComponent<GunnerPathScript> ();
		last_position = transform.position; 
	}

	void Update () {
		float distance = Vector3.Distance (PathToFollow.path_objs [CurrentWayPointID].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime * gunnerSpeed);	
	
		PointTowards (); 

		if (distance <= reachDistance) {
			CurrentWayPointID++;
		}

		if (CurrentWayPointID >= PathToFollow.path_objs.Count) {
			CurrentWayPointID = 13;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("BulletProgressionObject"))
			Destroy (this.gameObject);

		if (other.gameObject.CompareTag ("GunnerProgressionObject")) 
			Destroy (other.gameObject);

		if (other.gameObject.CompareTag ("LaserGate"))
			//levelManager.LoadScene(string name)
			SceneManager.LoadScene (restartLevel);

		if (other.gameObject.CompareTag ("NextLevel"))
			//levelManager.nextLevel; 
			SceneManager.LoadScene (nextLevel);
	}

	public void PointTowards(){ 
		var gunnerRotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Lerp(transform.rotation, gunnerRotation, Time.deltaTime * rotatationSpeed); 
	}
}

