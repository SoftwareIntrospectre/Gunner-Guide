using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorPathScript : MonoBehaviour {

		public Color rayColor = Color.white;
		public List<Transform> path_objs = new List<Transform>();
		Transform[] theArray;

		void OnDrawGizmos(){
			Gizmos.color = rayColor;
			theArray = GetComponentsInChildren<Transform> ();
			path_objs.Clear (); //clears the array with each runthrough

			//checks to see if current path_obj is the same as the one on the game object
			//if not, add a new one
			foreach(Transform path_obj in theArray){
				if (path_obj != this.transform) {
					path_objs.Add (path_obj);
				}
			} 
			//go through the array
			for (int i = 0; i < path_objs.Count; i++) {

				//establish what the current path_obj is
				Vector3 current = path_objs [i].position;

				//if the list is bigger than zero,
				if (i > 0)
				{
					//establish the previous path_obj (relative)
					Vector3 previous = path_objs [i - 1].position;

					//literally draw a line FROM previous TO current
					Gizmos.DrawLine (previous, current);

					//draw wiresphere as waypoints (radius: current to 0.3f)
					Gizmos.DrawWireSphere (current, 0.3f);
				}
			}
		}
	}