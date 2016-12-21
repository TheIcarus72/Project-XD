using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MainCharacterVariables : MonoBehaviour {
	public bool movementEnabled = true;
	private int xAttack = 0;
	private Animator animator;
	public bool hasSword = false;
	public bool hasRifle = false;
	public float swordGrabDelay = 0.0f;
	public float swordHolsterDelay = 0.0f;
	public float hasSwordX = 0.0f;
	static public bool attack = false;
	public GameObject Sword;
	public GameObject Rifle;
	public GameObject bullet;
	public GameObject barrelExit;
	static public float swordDamage = 10.0f;
	static public float rifleDamage = 7.0f;
	bool Aiming = false;

	void Awake (){
		animator = GetComponent<Animator>();
	}
	void LateUpdate() {
		if (Input.GetKeyDown (KeyCode.Alpha1) && movementEnabled)
		{
			Aiming = false;
			if (hasRifle && !attack) {
				hasRifle = false;
				animator.SetBool("HasRifle",false);
			}
			if (!hasSword && !attack) {
				hasSwordX = swordGrabDelay;
				hasSword = true;
				animator.SetBool("HasSword",true);
			}else if (hasSword && !attack) {
				hasSwordX = swordHolsterDelay;
				hasSword = false;
				animator.SetBool("HasSword",false);
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && movementEnabled)
		{
			Aiming = false;
			if (!hasRifle && !attack && hasSword) {
				hasSword = false;
				animator.SetBool("HasSword",false);
				hasSwordX = swordHolsterDelay;
				hasRifle = true;
				animator.SetBool("HasRifle",true);
			}else if(!hasRifle && !attack && !hasSword) {
				hasSword = false;
				animator.SetBool("HasSword",false);
				hasSwordX = 0f;
				hasRifle = true;
				animator.SetBool("HasRifle",true);
			}else if (hasRifle && !attack) {
				hasSwordX = 0f;
				hasRifle = false;
				animator.SetBool("HasRifle",false);
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && movementEnabled)
		{
			Aiming = false;
			if (!hasRifle && !attack && hasSword) {
				hasSword = false;
				animator.SetBool("HasSword",false);
				hasSwordX = swordHolsterDelay;
				hasRifle = false;
				animator.SetBool("HasRifle",false);
			}else if(!hasRifle && !attack && !hasSword) {
				hasSword = false;
				animator.SetBool("HasSword",false);
				hasSwordX = 0f;
				hasRifle = false;
				animator.SetBool("HasRifle",false);
			}else if (hasRifle && !attack && !hasSword) {
				hasSwordX = 0f;
				hasRifle = false;
				animator.SetBool("HasRifle",false);
			}
		}
	}
	void Update () {
		if (hasSwordX > 0 && hasSword) {
			hasSwordX -= 1 * Time.deltaTime;
		}
		if (hasSwordX <= 0 && hasSword) {
			Sword.SetActive(true);
			hasSwordX = 0.0f;
		}
		if (hasSwordX > 0 && !hasSword) {
			hasSwordX -= 1 * Time.deltaTime;
		}
		if (hasSwordX <= 0 && !hasSword) {
			Sword.SetActive(false);
			hasSwordX = 0.0f;
		}
		if (hasSwordX <= 0 && hasRifle) {
			Rifle.SetActive(true);
		}
		if (hasSwordX <= 0 && !hasRifle) {
			Rifle.SetActive(false);
		}
		if (attack == true && hasSword) {
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
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && attack == false && hasSword == true && movementEnabled)
		{
			attack = true;
			animator.SetBool ("Attack",true);
		}
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && attack == false && hasRifle == true && Aiming == true && movementEnabled)
		{
			attack = true;
			animator.SetBool ("Attack",true);
			fireBullet();
		}
		if(CrossPlatformInputManager.GetButtonDown("Fire2") && movementEnabled){
			if(hasRifle){
				Aiming = true;
				animator.SetBool("Aiming",true);
			}
		}
		if(CrossPlatformInputManager.GetButton("Fire2") && movementEnabled){
			if(!hasRifle){
				Aiming = false;
				animator.SetBool("Aiming",false);
			}
		}
		if(CrossPlatformInputManager.GetButtonUp("Fire2") && movementEnabled){
			Aiming = false;
			animator.SetBool("Aiming",false);
		}

	}

	private void fireBullet(){
		{
			GameObject Bullet = Instantiate(bullet, barrelExit.transform.position, Quaternion.identity) as GameObject;
		}
	}
}