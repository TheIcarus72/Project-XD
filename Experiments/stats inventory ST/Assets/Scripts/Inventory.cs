using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	//public int slotsX, slotsY;
	//public GUISkin skin;
	public List<GameObject> slots = new List<GameObject> ();
	public List<Item> items = new List<Item> ();
	//////////////////////public List<Item> inventory = new List<Item>();
	private itemDatabase database;
	private giveSprite spriter;

	public GameObject inventoryDisplay;
	public bool inventoryShowing = false;
	public PlayerScript playerScript;
	public Statshud statsHudScript;

	GameObject inventoryPanel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;

	// Use this for initialization
	void Start () {
		//enables acces to item database, then we can add items to the inventory
		database = GetComponent<itemDatabase> ();
		spriter = GetComponent<giveSprite> ();

		slotAmount = 25;
		inventoryPanel = GameObject.Find ("inventory Panel");
		for (int i = 0; i < slotAmount; i++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent (slotPanel.transform);
		}

		//tell function what item to add to th inventory
		AddItem (0);


		/*for(int i = 0; i < (slotsX * slotsY); i++){
			slots.Add(new Item());
		}*/

		////////////////////inventory.Add(database.items[0]);
	}

	public void AddItem(int id){
		// get desireable item
		Item itemToAdd = database.FetchItemByID(id);
		print (itemToAdd.itemName);

		// check for empty slot
		for(int i = 0; i < items.Count; i++){
			if(items[i].itemID == -1){		
				items[i] = itemToAdd;
				GameObject itemObj = Instantiate(inventoryItem);
				itemObj.transform.SetParent(slots[i].transform);
				itemObj.GetComponent<Image> ().sprite = spriter.SpriteB(itemToAdd.itemID, itemToAdd.itemSlug);
				//Debug.Log (itemToAdd.Sprite);
				Debug.Log (itemToAdd.itemSlug);
				itemObj.transform.position = Vector2.zero;		//middle of the slot, to add icon
				itemObj.name = itemToAdd.itemName;		// change name in hierarchy
				break;
			}
		}
	}

	/*
	// calling DrawInventory when we press the I button and showInventory is true
	void OnGUI(){
		GUI.skin = skin;
		if (inventoryShowing){
			DrawInventory ();
			Debug.Log (inventoryShowing);
		}
	}

	// must be called from within gui to use gui elements
	// making a grid for the inventory
	void DrawInventory(){
		for(int x = 0; x < slotsX; x++){
			for(int y = 0; x < slotsY; y++){
				GUI.Box (new Rect(x * 60, y * 60, 50, 50), "", skin.GetStyle("Slot"));
				Debug.Log (inventoryShowing);
			}
		}
	}*/

	// Update is called once per frame
	void Update () {
		//When key 'i' is pressed, activate or deactivate inventory
		//dissable movement
		if(Input.GetKeyDown(KeyCode.I)){
			if (statsHudScript.statsHudShowing == false) {
				playerScript.movementEnabled = false;
				inventoryShowing = !inventoryShowing;
			}
		}
		//When the escape key is pressed, deactivate stats canvas
		//enable movement
		if(Input.GetKeyDown(KeyCode.Escape) && inventoryShowing){
			playerScript.movementEnabled = true;
			inventoryShowing = !inventoryShowing;
		}

		if (inventoryShowing) {
			inventoryDisplay.SetActive (true);
		} else {
			inventoryDisplay.SetActive (false);
		}
	}
}
