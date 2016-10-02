using UnityEngine;
using System.Collections;

public class Enemy_BaTargetScript : MonoBehaviour {

/*What I want this to do:
 * 
 * General Pattern
	 *  Bat flies (xz - vertical). relative to wall - diagonally
	 *  moves forward at (variable) speed
	 *  If there's an oncoming moving object in its view, go backward at (variable) increased speed.
 	 * 
 * Horizontal Pattern
	 * Bat flies upward and downward at 45 degree angles (on X and Z axes) - diagonally.
	 * If going up and approaches the wall, then go down forward
	 * If going down and approaches the wall, then go up forward
	 * If there's a wall directly forward that blocks the path, go the opposite direction
	 * 
 * Vertical Pattern
 *  * Bat flies leftward and rightward at 45 degree angles (on X and Z axes) - diagonally.
	 * If going right and approaches the wall, then go diagonally down forward
	 * If going left and approaches the wall, then go down forward
	 * If there's a wall directly forward that blocks the path, go the opposite direction
 * 
 * If there's a BullTarget charging, increase speed to (variable), and turn the corner (go down on X axis), change 
 * 
 * 
 * Probably going to need a NavMeshAgent to make this work properly
 * */
}
