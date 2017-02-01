using UnityEngine;
using System.Collections;

public class room : MonoBehaviour {
	[SerializeField]
	bool room1;
	[SerializeField]
	bool room2;
	[SerializeField]
	bool room3;
	[SerializeField]
	bool empty;
	[SerializeField]
	float floorHeight;
	[SerializeField]
	float roofHeight;

	[SerializeField]
	GameObject hallway;
	[SerializeField]
	GameObject closedDoor;
	[SerializeField]
	GameObject objects1;
	[SerializeField]
	GameObject objects2;
	[SerializeField]
	GameObject objects3;
	[SerializeField]
	GameObject objects4;
	[SerializeField]
	GameObject room_light;

	public bool northHallway;
	public bool eastHallway;
	public bool southHallway;
	public bool westHallway;


	float hallOffsetX = 38.0f;
	float hallOffsetZ = 38.0f;
	float doorOffsetX = 26.0f;
	float doorOffsetZ = 26.0f;
	float lightOffset = 12.0f;

	// Use this for initialization
	void Start () {
		createDoorsAndHallways();
		createObjects();
		createLights();
	}
		
	
	// Update is called once per frame
	void Update () {
	
	}

	void createDoorsAndHallways () {
		if (northHallway == true) {
			if (transform.position.z < 760) {
				GameObject hall = Instantiate (hallway, new Vector3 ((this.gameObject.transform.position.x), 0, (this.gameObject.transform.position.z + hallOffsetZ)), Quaternion.identity) as GameObject;
				hall.transform.parent = this.gameObject.transform;
				GameObject hall_light1 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x), (this.gameObject.transform.position.y + 7.5f), (this.gameObject.transform.position.z + hallOffsetZ)), Quaternion.Euler (0, 0, 0)) as GameObject;
				hall_light1.transform.parent = this.gameObject.transform;
			} else  if(eastHallway != false || southHallway != false || westHallway != false){
				GameObject door = Instantiate (closedDoor, new Vector3 ((this.gameObject.transform.position.x), 0, (this.gameObject.transform.position.z + doorOffsetZ)), Quaternion.identity) as GameObject;
				door.transform.parent = this.gameObject.transform;
			}
		}
		if (eastHallway == true) {
			if (transform.position.x < 684) {
				GameObject hall = Instantiate (hallway, new Vector3 ((this.gameObject.transform.position.x + hallOffsetX), 0, (this.gameObject.transform.position.z)), Quaternion.Euler (0, 90, 0)) as GameObject;
				hall.transform.parent = this.gameObject.transform;
				GameObject hall_light1 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + hallOffsetX), (this.gameObject.transform.position.y + 7.5f), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				hall_light1.transform.parent = this.gameObject.transform;
			} else if(northHallway != false || southHallway != false || westHallway != false){
				GameObject door = Instantiate (closedDoor, new Vector3 ((this.gameObject.transform.position.x + doorOffsetX), 0, (this.gameObject.transform.position.z)), Quaternion.Euler (0, 90, 0)) as GameObject;
				door.transform.parent = this.gameObject.transform;
			}
		}
		if (northHallway == false) {
			if(empty == false){
				GameObject door = Instantiate (closedDoor, new Vector3 ((this.gameObject.transform.position.x), 0, (this.gameObject.transform.position.z + doorOffsetZ)), Quaternion.identity) as GameObject;
				door.transform.parent = this.gameObject.transform;
			}
		}
		if (eastHallway == false) {
			if(empty == false){
				GameObject door = Instantiate (closedDoor, new Vector3 ((this.gameObject.transform.position.x + doorOffsetX), 0, (this.gameObject.transform.position.z)), Quaternion.Euler (0, 90, 0)) as GameObject;
				door.transform.parent = this.gameObject.transform;
			}
		}
		if (southHallway == false) {
			if(empty == false){
				GameObject door = Instantiate (closedDoor, new Vector3 ((this.gameObject.transform.position.x), 0, (this.gameObject.transform.position.z - doorOffsetZ)), Quaternion.identity) as GameObject;
				door.transform.parent = this.gameObject.transform;
			}
		}
		if (westHallway == false) {
			if(empty == false){
				GameObject door = Instantiate (closedDoor, new Vector3 ((this.gameObject.transform.position.x - doorOffsetX), 0, (this.gameObject.transform.position.z)), Quaternion.Euler (0, 90, 0)) as GameObject;
				door.transform.parent = this.gameObject.transform;
			}
		}
	}

	void createObjects () {
		if(empty == false){
			int pickObjects = Random.Range (0, 5);
			switch (pickObjects) {
			case 0:
				GameObject room_objects0 = Instantiate (objects1, new Vector3 ((this.gameObject.transform.position.x), (this.gameObject.transform.position.y + floorHeight), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_objects0.transform.parent = this.gameObject.transform;
				break;
			case 1:
				GameObject room_objects1 = Instantiate (objects2, new Vector3 ((this.gameObject.transform.position.x), (this.gameObject.transform.position.y + floorHeight), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_objects1.transform.parent = this.gameObject.transform;
				break;
			case 2:
				GameObject room_objects2 = Instantiate (objects3, new Vector3 ((this.gameObject.transform.position.x), (this.gameObject.transform.position.y + floorHeight), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_objects2.transform.parent = this.gameObject.transform;
				break;
			case 3:
				GameObject room_objects3 = Instantiate (objects4, new Vector3 ((this.gameObject.transform.position.x), (this.gameObject.transform.position.y + floorHeight), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_objects3.transform.parent = this.gameObject.transform;
				break;
			}
		}
	}

	void createLights () {
		if(empty == false){
			if(room1 == true){
				GameObject room_light1 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x - lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z - lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light1.transform.parent = this.gameObject.transform;
				GameObject room_light2 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x - lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z + lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light2.transform.parent = this.gameObject.transform;
				GameObject room_light3 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z - lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light3.transform.parent = this.gameObject.transform;
				GameObject room_light4 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z + lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light4.transform.parent = this.gameObject.transform;
			} else if (room2 == true){
				GameObject room_light1 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x - lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z - lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light1.transform.parent = this.gameObject.transform;
				GameObject room_light2 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x - lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z + lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light2.transform.parent = this.gameObject.transform;
				GameObject room_light3 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z - lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light3.transform.parent = this.gameObject.transform;
				GameObject room_light4 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + lightOffset), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z + lightOffset)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light4.transform.parent = this.gameObject.transform;
			} else if (room3 == true){
				GameObject room_light1 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x - 15), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light1.transform.parent = this.gameObject.transform;
				GameObject room_light2 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z + 15)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light2.transform.parent = this.gameObject.transform;
				GameObject room_light3 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + 10), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light3.transform.parent = this.gameObject.transform;
				GameObject room_light4 = Instantiate (room_light, new Vector3 ((this.gameObject.transform.position.x + 10), (this.gameObject.transform.position.y + roofHeight), (this.gameObject.transform.position.z - 15)), Quaternion.Euler (0, 0, 0)) as GameObject;
				room_light4.transform.parent = this.gameObject.transform;
			}
		}
	}
}
