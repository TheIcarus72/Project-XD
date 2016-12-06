using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	// creating all things an item concists of
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemPower;
	public ItemType itemType;
	public int itemWeight;

	public enum ItemType{
		weapons,
		consumables,
		money,
		armor,
		boots,
		shields
	}

	//Making a way to add items by code >> itemDatabase script
	public Item(string name, int id, string desc, int power, ItemType type, int weight){
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D> ("Item Icons/" + name);
		itemPower = power;
		itemType = type;
		itemWeight = weight;
	}
}
