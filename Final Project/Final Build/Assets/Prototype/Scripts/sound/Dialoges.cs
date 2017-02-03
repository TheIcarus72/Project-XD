using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialoges : MonoBehaviour {
	private int numberPickedUp = 0;
	public GameObject pickedUpText;
	public GameObject eToPickUpText;
	public AudioClip[] soundtrack;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		eToPickUpText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// updates text in stats, shows how many audiotapes have been picked up
		Text PUtext = pickedUpText.GetComponent<Text> ();
		PUtext.text = "Total audiotapes picked up: " + numberPickedUp.ToString() + "/10";
	}

	//function gets called every frame
	void OnTriggerStay(Collider other){
		//if no dialoge is playing & other trigger collider has the tag 'dialoge' & player has not picked up more than 9 audiotapes
		if (!source.isPlaying && other.gameObject.tag == "dialoge" && numberPickedUp <= 9) {
			//activate text
			eToPickUpText.SetActive (true);
			Text ETPUtext = eToPickUpText.GetComponent<Text> ();
			ETPUtext.text = "Press 'e' to pick up audiotape!";

			//if player presses on 'e'
			if (Input.GetKeyDown(KeyCode.E)) {
				//play soundtrack with corresponding number & delete audiotape & deactivate text
				source.PlayOneShot (soundtrack [numberPickedUp], 1f);
				numberPickedUp++;
				Destroy (other.gameObject);
				eToPickUpText.SetActive (false);
			} 
		}
	}

	//display text if there is still audio playing from the previous audiotape
	void OnTriggerEnter(Collider other){
		if(source.isPlaying && other.gameObject.tag == "dialoge" && numberPickedUp <= 9) {
			eToPickUpText.SetActive (true);
			Text ETPUtext = eToPickUpText.GetComponent<Text> ();
			ETPUtext.text = "Wait until the audio is done playing";
		}
	}
}
