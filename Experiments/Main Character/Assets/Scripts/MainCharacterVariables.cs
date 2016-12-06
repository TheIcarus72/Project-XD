using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MainCharacterVariables : MonoBehaviour {
	
	private int xAttack = 0;
	private Animator animator;
	public bool hasSword = false;
	public float displaySwordDelay = 0.0f;
	float hasSwordX = 0.0f;
	static public bool attack = false;
	public GameObject Sword;
	static public float swordDamage = 10.0f;
	public GameObject WeaponEquipTest;


	void Awake () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter (Collider col) {
		if( col.gameObject.tag == "GrabWeaponTest" )
		{
			hasSwordX = displaySwordDelay;
			hasSword = true;
			animator.SetBool("HasSword",true);
			WeaponEquipTest.SetActive(false);
		}
	}

	void Update () {
		if (hasSwordX > 0 && hasSword) {
			hasSwordX -= 1 * Time.deltaTime;
		} else if (hasSwordX <= 0 && hasSword) {
			Sword.SetActive(true);
			hasSwordX = 0.0f;
		}
		if(attack == true)
		{
			if (xAttack < 40) {
				xAttack++;
			} else {
				xAttack = 0;
				attack = false;
				animator.SetBool ("Attack", false);
			}
				
		}
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && attack == false && hasSword == true)
		{
			attack = true;
			animator.SetBool ("Attack",true);
		}
	}
}