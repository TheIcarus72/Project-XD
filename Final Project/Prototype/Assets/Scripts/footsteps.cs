using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour {

	public CharacterControl characterControlScript;
	public AudioClip footstep;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//running
		if (Input.GetKeyDown (KeyCode.W)) {
			StopAllCoroutines ();
			StartCoroutine ("running");
		}
		if (Input.GetKey (KeyCode.W) && (Input.GetKeyUp (KeyCode.C) || Input.GetKeyUp (KeyCode.LeftShift))) {
			StopAllCoroutines ();
			StartCoroutine ("running");
		}


		//walking
		if (Input.GetKey (KeyCode.W) && Input.GetKeyDown (KeyCode.LeftShift)) {
			StopAllCoroutines ();
			StartCoroutine ("walking");
		}
		if (Input.GetKeyDown (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			StopAllCoroutines ();
			StartCoroutine ("walking");
		}


		//crouchedWalking
		if (Input.GetKeyDown (KeyCode.W) && Input.GetKeyDown (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}



		//if (Input.GetKeyDown (KeyCode.W)) {										//crouchedTurning
		//	StopAllCoroutines ();
		//	StartCoroutine ("crouchedTurning");
		//}



		if (Input.GetKeyUp (KeyCode.W)){
			StopAllCoroutines ();
		}
	}

	IEnumerator walking(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (0.492f);
			if (characterControlScript.InJump == true) {
				yield return new WaitForSeconds (2f);
			}
		}
	}

	IEnumerator running(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (0.3f);
		}
	}

	IEnumerator crouchedWalking(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (1f);
		}
	}

	IEnumerator crouchedTurning(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (1f);
		}
	}
}
