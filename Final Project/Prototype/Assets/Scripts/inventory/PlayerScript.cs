using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 2f;
	public bool movementEnabled = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (movementEnabled == true) {
			
			if (Input.GetButton ("leftButton")) {
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}

			if (Input.GetButton ("rightButton")) {
				transform.Translate (Vector3.right * speed * Time.deltaTime);
			}

			if (Input.GetButton ("upButton")) {
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}

			if (Input.GetButton ("downButton")) {
				transform.Translate (Vector3.back * speed * Time.deltaTime);
			}

		}

	}
}
