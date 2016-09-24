using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;

public class SFX_Interaction_Script: MonoBehaviour {

	public AudioSource playSFX;
	public string loadLevel;

	void Start(){
		playSFX = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Gunner")){
			StartCoroutine(PlaySFX_Function ());
		}
	}

	public IEnumerator PlaySFX_Function(){ 
		playSFX.Play (); 
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene (loadLevel); 
	}
}


