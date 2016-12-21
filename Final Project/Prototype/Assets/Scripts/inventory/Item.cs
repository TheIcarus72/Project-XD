using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Item {
	// creating all things an item concists of
	public string itemName;
	public int itemID;
	public string itemDesc;
	//public Sprite Sprite;
	public int itemPower;
	public ItemType itemType;
	public int itemWeight;
	public string itemSlug;

	public enum ItemType{
		weapons,
		consumables,
		money,
		armor,
		boots,
		shields
	}


	//Making a way to add items by code >> itemDatabase script
	public void ItemInfo(string name, int id, string desc, int power, ItemType type, int weight, string slug){
		itemName = name;
		itemID = id;
		itemDesc = desc;
		//Sprite = giveSprite (id, slug); //Resources.Load<Sprite> (slug) as Sprite;
		//Debug.Log ("1");
		itemPower = power;
		itemType = type;
		itemWeight = weight;
		itemSlug = slug;
	}

	public Item(){
		this.itemID = -1;
	}
}
