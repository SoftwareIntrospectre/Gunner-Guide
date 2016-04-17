using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GunnerPathScript : MonoBehaviour {

	public Color rayColor = Color.white;
	public List<Transform> waypoint = new List<Transform>();
	Transform[] arrayOfWaypoints;

	void OnDrawGizmos(){
		Gizmos.color = waypointsPathColor;
		arrayOfWaypoints = GetComponentsInChildren<Transform> ();
		arrayOfWaypoints.Clear (); 

		foreach(Transform waypoint in arrayOfWayPoints){
			if (waypoints != this.transform) {
				waypoint.Add (waypoint);
			}
		} 

		for (int numberOfWaypoints = 0; numberOfWaypoints < waypoint.Count; numberOfWaypoints++) {
			Vector3 current = waypoint [numberOfWaypoints].position;
			if (numberOfWaypoints > 0) {
				Vector3 previous = waypoint [numberOfWaypoints - 1].position;
				Gizmos.DrawLine (previous, current);
				Gizmos.DrawWireSphere (current, 0.3f);
			}
		}
	}
}

