using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_BullTargetScript : MonoBehaviour {

	MovementPathScript movementPathScript;
	public Transform bullTransform;

	public int waypointID = 0;

	//access MovementPathScript for PathRepeat() Function
	void Start(){
		movementPathScript = GetComponent<MovementPathScript> ();
		bullTransform = transform;
	
	}

	//allows BullTarget to move in a loop
	void Update(){
		movementPathScript.DistanceFunction ();
		movementPathScript.PathRepeat();
	}



/*What I want this to do:
 * 
 * Walks slowly forward
 * If there's a Gunner or Magic Bullet in its field of view, charge at (variable) speed;
 * Howl for signify about to charge
 * If it doesn't hit anything during its charge, have it impact the wall and be stunned for (variable) seconds;
 * 
 * Front is completely immune to all damage, back is its weakness
 * 
 * If it walks to the end of the path, have it turn the corner and move further on its patrol.
 * 
 * 
 * 
 */
}
