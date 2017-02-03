using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour {
	
	// to acces variables from other script
	public CharacterControl characterControlScript;
	public MainCharacterVariables weaponScript;

	public float walk = 0.48f;
	public float run = 0.285f;
	public float crouch = 0.44f;
	public AudioClip footstep;
	private AudioSource source;

	private bool drawingSwordFG = false;
	private bool drawingSwordFE = false;
	private bool drawingGunFS = false;
	private bool drawingGunFE = false;

	// Use this for initialization
	void Start () {
		// get acces to audiosource
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//stop coroutine is used to stop coroutines from overlapping


		//running
		//startcoroutine if W is pressed
		if (Input.GetKeyDown (KeyCode.W)) {
			StopAllCoroutines ();
			StartCoroutine ("running");
		}
		//startcoroutine if W is being pressed and c or shift is unpressed(keyup)
		if (Input.GetKey (KeyCode.W) && (Input.GetKeyUp (KeyCode.C) || Input.GetKeyUp (KeyCode.LeftShift) )) {
			StopAllCoroutines ();
			StartCoroutine ("running");
		}


		//walking
		//startcoroutine if W is being pressed and shift pressed
		if (Input.GetKey (KeyCode.W) && Input.GetKeyDown (KeyCode.LeftShift)) {
			StopAllCoroutines ();
			StartCoroutine ("walking");
		}
		//startcoroutine if W is pressed and shift being pressed
		if (Input.GetKeyDown (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			StopAllCoroutines ();
			StartCoroutine ("walking");
		}
		//startcoroutine if W is being pressed and shift being pressed and C is unpressed
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift) && Input.GetKeyUp (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("walking");
		}


		//crouchedWalking
		//startcoroutine if W is being pressed and C pressed
		if (Input.GetKey (KeyCode.W) && Input.GetKeyDown (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}
		//startcoroutine if W is pressed and C being pressed
		if (Input.GetKeyDown (KeyCode.W) && Input.GetKey (KeyCode.C)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}
		//startcoroutine if W is being pressed and C being pressed and shift is unpressed
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.C) && Input.GetKeyUp (KeyCode.LeftShift)) {
			StopAllCoroutines ();
			StartCoroutine ("crouchedWalking");
		}


		//if (Input.GetKeyDown (KeyCode.W)) {										//crouchedTurning
		//	StopAllCoroutines ();
		//	StartCoroutine ("crouchedTurning");
		//}

		//if current weapon is rifle, and switch to sword, wait for sec
		if(weaponScript.hasRifle == true && Input.GetKeyDown (KeyCode.Alpha1)){
			drawingSwordFG = true;
		}
		//if current weapon is sword, and switch to rifle, wait for sec
		if(weaponScript.hasSword == true && Input.GetKeyDown (KeyCode.Alpha2)){
			drawingGunFS = true;
		}
		//if current weapon is neither rifle or sword (empty), and switch to sword, wait for sec
		if(weaponScript.hasRifle == false && weaponScript.hasSword == false && Input.GetKeyDown (KeyCode.Alpha1) ){
			drawingSwordFE = true;
		}
		//if current weapon is neither rifle or sword (empty), and switch to rifle, bool is true
		if(weaponScript.hasRifle == false && weaponScript.hasSword == false && Input.GetKeyDown (KeyCode.Alpha2) ){
			drawingGunFE = true;
		}


		// stop coroutines if W key is up or if movement is restricted
		if(Input.GetKeyUp (KeyCode.W)){
			StopAllCoroutines ();
		}
			
		/*if (characterControlScript.restrictForward == true || characterControlScript.restrictBackward == true ){
			StopAllCoroutines ();
		}*/
	}

	//makes footsteps sounds while walking
	IEnumerator walking(){
		while (true) {
			//play one footstep
			source.PlayOneShot (footstep, 0.8f);
			//wait for a set amount of seconds to play one footstep again
			yield return new WaitForSeconds (walk);
			//wait 0.5 sec if the player is jumping
			if (characterControlScript.Grounded == false) {
				yield return new WaitForSeconds (0.5f);
			}
			//if current weapon is rifle, and switch to sword, wait for sec
			if(drawingSwordFG){
				yield return new WaitForSeconds (1f);
				drawingSwordFG = false;
			}
			//if current weapon is sword, and switch to rifle, wait for sec
			if(drawingGunFS){
				yield return new WaitForSeconds (1f);
				drawingGunFS = false;
			}
			//if current weapon is neither rifle or sword (empty), and switch to sword, wait for sec
			if(drawingSwordFE){
				yield return new WaitForSeconds (1f);
				drawingSwordFE = false;
			}
			//if current weapon is neither rifle or sword (empty), and switch to rifle, wait for sec
			if(drawingGunFE ){
				yield return new WaitForSeconds (0.2f);
				drawingGunFE = false;
			}
		}
	}

	//makes footsteps sounds while running
	IEnumerator running(){
		while (true) {
			//play one footstep
			source.PlayOneShot (footstep, 0.8f);
			//wait for a set amount of seconds to play one footstep again
			yield return new WaitForSeconds (run);
			//wait 0.5 sec if the player is jumping
			if (characterControlScript.Grounded == false) {
				yield return new WaitForSeconds (0.5f);
				Debug.Log ("sw");
			}
			//if current weapon is rifle, and switch to sword, wait for sec
			if(drawingSwordFG){
				yield return new WaitForSeconds (1f);
				drawingSwordFG = false;
			}
			//if current weapon is sword, and switch to rifle, wait for sec
			if(drawingGunFS){
				yield return new WaitForSeconds (1f);
				drawingGunFS = false;
			}
			//if current weapon is neither rifle or sword (empty), and switch to sword, wait for sec
			if(drawingSwordFE){
				yield return new WaitForSeconds (1f);
				drawingSwordFE = false;
			}
			//if current weapon is neither rifle or sword (empty), and switch to rifle, wait for sec
			if(drawingGunFE ){
				yield return new WaitForSeconds (0.2f);
				drawingGunFE = false;
			}
		}
	}

	//makes footsteps sounds while crouch walking
	IEnumerator crouchedWalking(){
		while (true) {
			//play one footstep
			source.PlayOneShot (footstep, 0.8f);
			//wait for a set amount of seconds to play one footstep again
			yield return new WaitForSeconds (crouch);
		}
	}

	
	/*IEnumerator crouchedTurning(){
		while (true) {
			//play one footstep
			source.PlayOneShot (footstep, 0.8f);
			yield return new WaitForSeconds (0.455f);
		}
	}*/
}
