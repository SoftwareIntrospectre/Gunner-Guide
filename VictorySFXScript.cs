using UnityEngine;
using System.Collections;

public class VictorySFXScript : MonoBehaviour {

	public AudioSource victorySoundEffect;
	public MovementPathScript movementPathReference; 

	void Start(){
		movementPathReference = GetComponent<MovementPathScript> ();
	}


	void Update () {
		if (movementPathReference.gunnerIsHurryingToFinish = true)
			victorySoundEffect.Play ();
	}
}
