using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemDatabase : MonoBehaviour {
	//creating a database for all items
	public List<Item> items = new List<Item>();

	//Here we can add items to the database
	void Start(){
		items.Add (new Item ("Starter weapon", 0, "The most basic weapon", 1, Item.ItemType.weapons, 10));

	}
}
