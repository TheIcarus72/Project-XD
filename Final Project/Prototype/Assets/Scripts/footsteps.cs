using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour {

	public CharacterControl characterControlScript;
	public float walk = 0.48f;
	public float run = 0.285f;
	public float crouch = 0.44f;
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
		if (Input.GetKey (KeyCode.W) && (Input.GetKeyUp (KeyCode.C) || Input.GetKeyUp (KeyCode.LeftShift) )) {
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
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift) && Input.GetKeyUp (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("walking");
		}


		//crouchedWalking
		if (Input.GetKey (KeyCode.W) && Input.GetKeyDown (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}
		if (Input.GetKeyDown (KeyCode.W) && Input.GetKey (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.C) && Input.GetKeyUp (KeyCode.LeftShift)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}


		//if (Input.GetKeyDown (KeyCode.W)) {										//crouchedTurning
		//	StopAllCoroutines ();
		//	StartCoroutine ("crouchedTurning");
		//}


		// stop coroutines if W key is up or if movement is restricted
		if (Input.GetKeyUp (KeyCode.W)){
			StopAllCoroutines ();
		}
		/*if (characterControlScript.restrictForward == true || characterControlScript.restrictBackward == true ){
			StopAllCoroutines ();
		}*/
	}

	IEnumerator walking(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (walk);
			if (characterControlScript.Grounded == false) {
				yield return new WaitForSeconds (0.5f);
			}
		}
	}

	IEnumerator running(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (run);
			if (characterControlScript.Grounded == false) {
				yield return new WaitForSeconds (0.5f);
			}
		}
	}

	IEnumerator crouchedWalking(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (crouch);
		}
	}

	/*IEnumerator crouchedTurning(){
		while (true) {
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (0.455f);
		}
	}*/
}
