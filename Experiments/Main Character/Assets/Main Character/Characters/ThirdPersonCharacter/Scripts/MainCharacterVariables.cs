using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MainCharacterVariables : MonoBehaviour {
	public bool hasWeapon = false;
	public bool attack = false;

	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter (Collider col) {
		if( col.gameObject.tag == "GrabWeaponTest" )
		{
			hasWeapon = true;
		}
	}

	void Update () {
		if(attack == true)
		{
			attack = false;

		}
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && attack == false && hasWeapon == true)
		{
			attack = true;
			animator.SetBool ("Attack",true);
			Debug.Log("Attack");
		}
	}
}