	using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	static public bool restrictForward = false;
	static public bool restrictBackward = false;
	static public bool restrictLeft = false;
	static public bool restrictRight = false;

	public GameObject cameraPivot;
	public float walkRunTransitionSpeed = 1.0f;
	public float jumpPower = 1.0f;
	private Animator animator;
	float v = 0.0f;
	float h = 0.0f;
	float vCurrent = 0.0f;
	bool Grounded = true;
	bool Crouched = false;
	bool Jump = false;
	bool InJump = false;
	float jumpX =  0;
	float lastJumpX = 0;
	bool cameraCrouched = false;
	Rigidbody rb;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () {
		if (Grounded && !Jump && !InJump) {
			rb.AddForce (Physics.gravity * rb.mass);
		}
		if (Crouched == true && cameraCrouched == false) {
			Vector3 cameraPivotPos = cameraPivot.transform.position;
			cameraPivot.transform.position = new Vector3 (cameraPivotPos.x, cameraPivotPos.y - 0.5f, cameraPivotPos.z);
			cameraCrouched = true;
		}
		if (Crouched == false && cameraCrouched == true) {
			Vector3 cameraPivotPos = cameraPivot.transform.position;
			cameraPivot.transform.position = new Vector3 (cameraPivotPos.x, cameraPivotPos.y + 0.5f, cameraPivotPos.z);
			cameraCrouched = false;
		}
		if (!InJump && !Grounded) {
			rb.AddForce (transform.forward * v * jumpPower * 1.5f * Time.deltaTime, ForceMode.Force);
		}
		if (InJump) {
			if (jumpX > 0) {
				if (jumpX > 0.5) {
					rb.AddForce (Vector3.up * jumpPower / 40 * Time.deltaTime, ForceMode.Force);
				}
				rb.AddForce (transform.forward * v * jumpPower * 1.5f * Time.deltaTime, ForceMode.Force);
			}
			jumpX -= 1 * Time.deltaTime;
		}
		if (!Grounded && Jump) {
			animator.SetBool ("Jump", false);
			Jump = false;
		}
		if (Grounded) {
			if (lastJumpX > 0) {
				lastJumpX -= 1 * Time.deltaTime;
			}
			InJump = false;
			animator.SetBool ("InJump", false);
			if (lastJumpX < 0) {
				lastJumpX = 0;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		

		if(Input.GetKeyDown (KeyCode.Space) && Grounded && !Jump && !InJump && lastJumpX <= 0) {
			Jump = true;
			animator.SetBool ("Jump",true);
			InJump = true;
			animator.SetBool ("InJump",true);
			jumpX = 1.5f;

			rb.AddForce(Vector3.up * jumpPower * 10 * Time.deltaTime,ForceMode.Force);
			rb.AddForce(transform.forward * v * jumpPower * 2 * Time.deltaTime,ForceMode.Force);
		}

		if (Input.GetKey (KeyCode.C) && Grounded) {
			animator.SetBool ("Crouch", true);				// Crouch is on
			Crouched = true;
			v = Input.GetAxis ("Vertical");					// setup v variables as our vertical input axis
			if (Input.GetKey (KeyCode.LeftAlt)) {
				h = Input.GetAxis ("Horizontal");				// setup h variable as our horizontal input axis
			} else {
				h = Input.GetAxis ("Horizontal") + Input.GetAxis ("Mouse X");
			}
			animator.SetFloat("Speed", v);					// set our animator's float parameter 'Speed' equal to the vertical input axis				
			animator.SetFloat("Direction", h); 				// set our animator's float parameter 'Direction' equal to the horizontal input axis
		} else {
			animator.SetBool ("Crouch", false);				// Crouch is off
			Crouched = false;
			if (Input.GetKey (KeyCode.LeftShift) && v >= 0) {
				v = Input.GetAxis ("Vertical") / 4;			// setup v variables as our vertical input axis
			} else {
				v = Input.GetAxis ("Vertical");
			}

			if (Input.GetKey (KeyCode.LeftAlt)) {
				h = Input.GetAxis ("Horizontal");				// setup h variable as our horizontal input axis
			} else {
				h = Input.GetAxis ("Horizontal") + Input.GetAxis ("Mouse X");
			}
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

			if (restrictForward) {
				v = Mathf.Clamp (v, -1.0f, 0.0f);
				vCurrent = Mathf.Clamp (vCurrent, -1.0f, 0.0f);
			}
			if (restrictBackward) {
				v = Mathf.Clamp (v, 0.0f, 1.0f);
				vCurrent = Mathf.Clamp (vCurrent, 0.0f, 1.0f);
			}
			if (restrictForward && restrictBackward) {
				v = Mathf.Clamp (v, 0.0f, 0.0f);
				vCurrent = Mathf.Clamp (vCurrent, 0.0f, 0.0f);
			}
			/*if (restrictLeft) {
				h = Mathf.Clamp (h, 0.0f, 1.0f);
			}
			if (restrictRight) {
				h = Mathf.Clamp (h, -1.0f, 0.0f);
			}*/



			animator.SetFloat("Speed", vCurrent);			// set our animator's float parameter 'Speed' equal to the vertical input axis				
			animator.SetFloat("Direction", h); 				// set our animator's float parameter 'Direction' equal to the horizontal input axis
		}
	}

	void OnTriggerStay (Collider col) {
		if (col.gameObject.tag != "PlayerMovementRestriction") {
			if (col.gameObject.tag == "Environment" && !Jump) {
				Grounded = true;
				animator.SetBool ("Grounded", true);
			} else if (col.gameObject.tag == "Environment" && Jump) {
				Grounded = false;
				animator.SetBool ("Grounded", false);
				lastJumpX = 0.5f;
			}
		}
	}
	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag != "PlayerMovementRestriction") {
			if (col.gameObject.tag == "Environment") {
				Grounded = false;
				animator.SetBool ("Grounded", false);
				lastJumpX = 0.5f;
			}
		}
	}

}
