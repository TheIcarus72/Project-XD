using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostPack : MonoBehaviour {
	
	public Statshud statsScript;
	public spawnPacks packsScript;

	void Start(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		statsScript = player.GetComponent <Statshud>();
		GameObject Handler = GameObject.FindGameObjectWithTag ("handler");
		packsScript = Handler.GetComponent <spawnPacks>();	}

	//if the object entering the trigger is the player
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			//add health and delete object if the object is a healthpack
			if (this.gameObject.tag == "health") {
				statsScript.health = statsScript.maxHealth;
				packsScript.healthPickUp = true;
				Destroy (this.gameObject);
			}

			//add energy and delete object if the object is a energypack
			if (this.gameObject.tag == "energy") {
				statsScript.energy = statsScript.energy + 100;
				packsScript.energyPickUp = true;
				Destroy (this.gameObject);
			}

			//add ammo and delete object if the object is an ammopack
			if (this.gameObject.tag == "ammo") {
				statsScript.ammoAmount = statsScript.ammoAmount + 30;
				packsScript.ammoPickUp = true;
				Destroy (this.gameObject);
			}
		}
	}
}
