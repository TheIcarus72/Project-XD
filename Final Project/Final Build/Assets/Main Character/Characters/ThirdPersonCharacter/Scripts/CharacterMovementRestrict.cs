using UnityEngine;
using System.Collections;

public class CharacterMovementRestrict : MonoBehaviour {
	public GameObject player;
	public bool restrictForward = false;
	public bool restrictBackward = false;
	public bool restrictLeft = false;
	public bool restrictRight = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		transform.rotation = player.transform.rotation;
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Environment" && restrictForward) {
			CharacterControl.restrictForward = true;
		}
		if (col.gameObject.tag == "Environment" && restrictBackward) {
			CharacterControl.restrictBackward = true;
		}
		if (col.gameObject.tag == "Environment" && restrictLeft) {
			CharacterControl.restrictLeft = true;
		}
		if (col.gameObject.tag == "Environment" && restrictRight) {
			CharacterControl.restrictRight = true;
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Environment" && restrictForward) {
			CharacterControl.restrictForward = false;
		}
		if (col.gameObject.tag == "Environment" && restrictBackward) {
			CharacterControl.restrictBackward = false;
		}
		if (col.gameObject.tag == "Environment" && restrictLeft) {
			CharacterControl.restrictLeft = false;
		}
		if (col.gameObject.tag == "Environment" && restrictRight) {
			CharacterControl.restrictRight = false;
		}
	}
}
