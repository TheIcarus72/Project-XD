using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	public PlayerScript playerScript;
	public Statshud statsHudScript;
	public bool inventoryShowing = false;
	public List<Item> inventory = new List<Item>();
	private itemDatabase database;
	public GameObject itemDatabase;
	public GameObject inventoryDisplay;

	// Use this for initialization
	void Start () {

		//enables acces to item database, then we can add items to the inventory
		database = itemDatabase.GetComponent<itemDatabase> ();
		inventory.Add(database.items[0]);
	}
	
	// Update is called once per frame
	void Update () {
		//When key 'i' is pressed, activate or deactivate inventory
		//dissable movement
		if(Input.GetKeyDown(KeyCode.I)){
			if (statsHudScript.statsHudShowing == false) {
				playerScript.movementEnabled = false;
				inventoryShowing = true;
			}
		}
		//When the escape key is pressed, deactivate stats canvas
		//enable movement
			if(Input.GetKeyDown(KeyCode.Escape)){
			playerScript.movementEnabled = true;
			inventoryShowing = false;
		}

		if (inventoryShowing) {
			inventoryDisplay.SetActive (true);
		} else {
			inventoryDisplay.SetActive (false);
		}
	}
}
