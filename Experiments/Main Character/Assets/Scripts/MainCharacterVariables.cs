using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MainCharacterVariables : MonoBehaviour {
	
	private int xAttack = 0;
	private Animator animator;
	public bool hasSword = false;
	public bool hasRifle = false;
	public float displaySwordDelay = 0.0f;
	float hasSwordX = 0.0f;
	static public bool attack = false;
	public GameObject Sword;
	public GameObject Rifle;
	static public float swordDamage = 10.0f;
	static public float rifleDamage = 7.0f;
	public GameObject SwordEquip;
	public GameObject RifleEquip;
	bool Aiming = false;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter (Collider col) {
		if( col.gameObject.tag == "GrabSword" )
		{
			hasSwordX = displaySwordDelay;
			hasSword = true;
			animator.SetBool("HasSword",true);
			SwordEquip.SetActive(false);
			RifleEquip.SetActive(true);
		}
		if( col.gameObject.tag == "GrabRifle" )
		{
			hasRifle = true;
			animator.SetBool("HasRifle",true);
			Rifle.SetActive(true);
			RifleEquip.SetActive(false);
			SwordEquip.SetActive(true);
		}
	}

	void Update () {
		if (hasSwordX > 0 && hasSword) {
			hasSwordX -= 1 * Time.deltaTime;
		} else if (hasSwordX <= 0 && hasSword) {
			Sword.SetActive(true);
			hasSwordX = 0.0f;
		}
		if(attack == true && hasSword)
		{
			if (xAttack < 40) {
				xAttack++;
			} else {
				xAttack = 0;
				attack = false;
				animator.SetBool ("Attack", false);
			}
				
		}
		if(attack == true && hasRifle)
		{
			if (xAttack < 20) {
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
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && attack == false && hasRifle == true && Aiming == true)
		{
			attack = true;
			animator.SetBool ("Attack",true);
		}
		if(CrossPlatformInputManager.GetButton("Fire2") && hasRifle == true) {
			Aiming = true;
			animator.SetBool("Aiming",true);
		} else {
			Aiming = false;
			animator.SetBool("Aiming",false);
		}
	}
}