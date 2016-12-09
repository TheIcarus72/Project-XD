using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using LitJson;
//using System.IO;

public class itemDatabase : MonoBehaviour {
	//creating a database for all items
	public List<Item> items = new List<Item>();
	//private JsonData itemData;

	//Here we can add items to the database
	void Start(){
		//itemData = JsonMapper.ToObject (File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		Item item = new Item();
		item.ItemInfo ("Starter weapon", 0, "The most basic weapon", 1, Item.ItemType.weapons,10, "starter_weapon");
		items.Add (item);
		Debug.Log (Item.ItemType.weapons);

	}

	public Item FetchItemByID(int id){
		for (int i = 0; i < items.Count; i++)
			if (items [i].itemID == id)
				return items [i];
		return null;
	}
}
