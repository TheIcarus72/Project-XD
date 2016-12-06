using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	public PlayerScript playerScript;
	public Statshud statsHudScript;
	public bool inventoryShowing = false;
	public List<Item> inventorY = new List<Item>();
	private itemDatabase database;
	public GameObject itemDatabase;

	// Use this for initialization
	void Start () {

		//enables acces to item database, then we can add items to the inventory
		database = itemDatabase.GetComponent<itemDatabase> ();
		inventorY.Add(database.items[0]);
	}
	
	// Update is called once per frame
	void Update () {
		//When key 'i' is pressed, activate or deactivate inventory
		//dissable movement
		if(Input.GetKeyDown("i")){
			if (statsHudScript.statsHudShowing == false) {
				playerScript.movementEnabled = false;
				inventoryShowing = !inventoryShowing;
			}
		}
		//When the escape key is pressed, deactivate stats canvas
		//enable movement
		if(Input.GetKeyDown("escape")){
			playerScript.movementEnabled = true;
			inventoryShowing = !inventoryShowing;
		}
	}
}
