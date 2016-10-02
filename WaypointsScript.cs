using UnityEngine;
using System.Collections;

public class WaypointsScript : MonoBehaviour {

	public GameObject[] waypoints;
	public int num = 0;

	public float minimumDistance;
	public float speed;

	public bool randomDirection = false;
	public bool go = true;

	void Update(){
		float distance = Vector3.Distance (gameObject.transform.position, waypoints[num].transform.position);

		if (go) {
			if (distance > minimumDistance) {
				MoveToNextWaypoint ();
			} 
			else {
				if (!randomDirection) {
					if (num + 1 == waypoints.Length) {
						num = 0;
					} 
					else {
						num++; 
					} //end of "else --> num++"
				} // end of "if (num + 1... --> else"
			} //end of "if(go) --> else"

		} //end of "if(go)"
	} //end of Update()

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("LaserGate")){
			go = false;
		}
			
	}

	void MoveToNextWaypoint(){
		gameObject.transform.LookAt (waypoints [num].transform.position);
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
		if (waypoints [num] == null) {
			waypoints.GetLength (num);
			MoveToNextWaypoint ();
		}
	}
}
