using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MainCharacterVariables : MonoBehaviour {
	private int xAttack = 0;
	private Animator animator;
	public bool hasWeapon = false;
	public bool attack = false;
	public GameObject Sword;
	public GameObject WeaponEquipTest;


	void Awake () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter (Collider col) {
		Debug.Log("Test");
		if( col.gameObject.tag == "GrabWeaponTest" )
		{
			hasWeapon = true;
			Sword.SetActive(true);
			WeaponEquipTest.SetActive(false);
		}
	}

	void Update () {
		if(attack == true)
		{
			if (xAttack < 60) {
				xAttack++;
			} else {
				xAttack = 0;
				attack = false;
				animator.SetBool ("Attack", false);
			}
				
		}
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && attack == false && hasWeapon == true)
		{
			attack = true;
			animator.SetBool ("Attack",true);
			Debug.Log("Attack");
		}
	}
}