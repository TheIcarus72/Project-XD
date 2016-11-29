using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	public float walkRunTransitionSpeed = 1.0f;
	private Animator animator;
	float v = 0.0f;
	float h = 0.0f;
	float vCurrent = 0.0f;
	//float hCurrent = 0.0f;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftShift)) {
			v = Input.GetAxis ("Vertical") / 4;				// setup v variables as our vertical input axis
		} else {
			v = Input.GetAxis ("Vertical");
		}
		h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		if (vCurrent > v) {
			vCurrent -= walkRunTransitionSpeed * Time.deltaTime;
			if (vCurrent < v) {
				vCurrent = v;
			}
		} else if (vCurrent < v) {
			vCurrent += walkRunTransitionSpeed * Time.deltaTime;
			if (vCurrent > v) {
				vCurrent = v;
			}
		}
		animator.SetFloat("Speed", vCurrent);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		animator.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis
		Debug.Log(v + " " + vCurrent);
	}
}
