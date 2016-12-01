	using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	public GameObject cameraPivot;
	public float walkRunTransitionSpeed = 1.0f;
	public float jumpPower = 1.0f;
	private Animator animator;
	float v = 0.0f;
	float h = 0.0f;
	float vCurrent = 0.0f;
	bool Grounded = false;
	bool Crouched = false;
	bool Jump = false;
	bool InJump = false;
	float jumpX =  0;
	bool cameraCrouched = false;
	Rigidbody rb;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () {
		if(Grounded && Jump == false)
		{
			rb.AddForce(Physics.gravity * rb.mass);
		}
		if(Crouched == true && cameraCrouched == false)
		{
			Vector3 cameraPivotPos = cameraPivot.transform.position;
			cameraPivot.transform.position = new Vector3(cameraPivotPos.x,cameraPivotPos.y - 0.5f,cameraPivotPos.z);
			cameraCrouched = true;
		}
		if(Crouched == false && cameraCrouched == true)
		{
			Vector3 cameraPivotPos = cameraPivot.transform.position;
			cameraPivot.transform.position = new Vector3(cameraPivotPos.x,cameraPivotPos.y + 0.5f,cameraPivotPos.z);
			cameraCrouched = false;
		}
		if(InJump && jumpX > 0)
		{
			jumpX -= 1 *Time.deltaTime;
			rb.AddForce(transform.forward * v * jumpPower * 1.5f * Time.deltaTime,ForceMode.Force);
		}

	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space) && Grounded && !Jump) {
			Jump = true;
			animator.SetBool ("Jump",true);
			InJump = true;
			jumpX = 1.5f;
			rb.AddForce(Vector3.up * jumpPower * 10 * Time.deltaTime,ForceMode.Force);
			rb.AddForce(transform.forward * v * jumpPower * 2 * Time.deltaTime,ForceMode.Force);
		}
		if(!Grounded && Jump){
			animator.SetBool ("Jump",false);
			Jump = false;
		}
		if(Grounded && !Jump)
		{
			InJump = false;
		}
		if (Input.GetKey (KeyCode.C) && Grounded) {
			animator.SetBool ("Crouch", true);				// Crouch is on
			Crouched = true;
			v = Input.GetAxis ("Vertical"); 				// setup v variables as our vertical input axis
			h = Input.GetAxis ("Horizontal");				// setup h variable as our horizontal input axis
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
			h = Input.GetAxis ("Horizontal");				// setup h variable as our horizontal input axis
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
			animator.SetFloat("Speed", vCurrent);			// set our animator's float parameter 'Speed' equal to the vertical input axis				
			animator.SetFloat("Direction", h); 				// set our animator's float parameter 'Direction' equal to the horizontal input axis
		}
	}

	void OnTriggerStay (Collider col) {
		if(col.gameObject.tag == "Environment")
		{
			Grounded = true;
			animator.SetBool("Grounded", true);
		}
	}
	void OnTriggerExit (Collider col) {
		if(col.gameObject.tag == "Environment")
		{
			Grounded = false;
			animator.SetBool("Grounded",false);
		}
	}

}
