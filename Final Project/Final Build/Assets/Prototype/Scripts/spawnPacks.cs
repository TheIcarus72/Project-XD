using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPacks : MonoBehaviour {

	public GameObject healthPrefab;
	public GameObject energyPrefab;
	public GameObject ammoPrefab;
	public bool healthPickUp = true;
	public bool energyPickUp = true;
	public bool ammoPickUp = true;
	bool canSpawnHealth = false;
	float timerH = 0;
	bool canSpawnEnergy = false;
	float timerE = 0;
	bool canSpawnAmmo = false;
	float timerA = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Health
		if(healthPickUp == true && canSpawnHealth == false){
			timerH += Time.deltaTime;
		}
		if (timerH > 30) {
			timerH = 0;
			canSpawnHealth = true;
		}
		if (healthPickUp == true && canSpawnHealth == true) {
			Instantiate (healthPrefab, new Vector3 (8, 0, 8), Quaternion.Euler (-90, 0, 0));
			healthPickUp = false;
			canSpawnHealth = false;
		}

		//Energy
		if(energyPickUp == true && canSpawnEnergy == false){
			timerE += Time.deltaTime;
		}
		if (timerE > 30) {
			timerE = 0;
			canSpawnEnergy = true;
		}
		if (energyPickUp == true && canSpawnEnergy == true) {
			Instantiate (energyPrefab, new Vector3 (4, 0, 8), Quaternion.identity);
			energyPickUp = false;
			canSpawnEnergy = false;
		}

		//Ammo
		if(ammoPickUp == true && canSpawnAmmo == false){
			//start timer
			timerA += Time.deltaTime;
		}
		if (timerA > 30) {
			//reset timer & enable spawn of new
			timerA = 0;
			canSpawnAmmo = true;
		}
		if (ammoPickUp == true && canSpawnAmmo == true) {
			//spawn new ammobox & disable new spawn
			Instantiate (ammoPrefab, new Vector3 (14, 0, 8), Quaternion.Euler (180, 0, 0));
			ammoPickUp = false;
			canSpawnAmmo = false;
		}
	}
}
