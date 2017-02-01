using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGen : MonoBehaviour {


	[SerializeField]
	GameObject roomN;
	[SerializeField]
	GameObject roomN2;
	[SerializeField]
	GameObject roomN3;
	[SerializeField]
	GameObject roomE;
	[SerializeField]
	GameObject roomE2;
	[SerializeField]
	GameObject roomE3;
	[SerializeField]
	GameObject roomNE;
	[SerializeField]
	GameObject roomNE2;
	[SerializeField]
	GameObject roomNE3;
	[SerializeField]
	GameObject roomNES;
	[SerializeField]
	GameObject roomNES2;
	[SerializeField]
	GameObject roomNES3;
	[SerializeField]
	GameObject roomNS;
	[SerializeField]
	GameObject roomNS2;
	[SerializeField]
	GameObject roomNS3;
	[SerializeField]
	GameObject roomES;
	[SerializeField]
	GameObject roomES2;
	[SerializeField]
	GameObject roomES3;
	[SerializeField]
	GameObject roomNEW;
	[SerializeField]
	GameObject roomNEW2;
	[SerializeField]
	GameObject roomNEW3;
	[SerializeField]
	GameObject roomNW;
	[SerializeField]
	GameObject roomNW2;
	[SerializeField]
	GameObject roomNW3;
	[SerializeField]
	GameObject roomEW;
	[SerializeField]
	GameObject roomEW2;
	[SerializeField]
	GameObject roomEW3;
	[SerializeField]
	GameObject roomNESW;
	[SerializeField]
	GameObject roomNESW2;
	[SerializeField]
	GameObject roomNESW3;
	[SerializeField]
	GameObject roomNSW;
	[SerializeField]
	GameObject roomNSW2;
	[SerializeField]
	GameObject roomNSW3;
	[SerializeField]
	GameObject roomESW;
	[SerializeField]
	GameObject roomESW2;
	[SerializeField]
	GameObject roomESW3;
	[SerializeField]
	GameObject roomSW;
	[SerializeField]
	GameObject roomSW2;
	[SerializeField]
	GameObject roomSW3;
	[SerializeField]
	GameObject roomEmpty;


	float offsetX = 76.0f;
	float offsetZ = 76.0f;

	public List<GameObject> rooms;
	// Use this for initialization
	void Start () {
		CreateRooms();
		FindLastRoom();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/// <summary>
	/// Creates the dungeon of rooms.
	/// </summary>
	void CreateRooms () {

		rooms = new List<GameObject> ();

		for (int x = 0; x < 10; x++) {
			for (int z = 1; z < 11; z++) {

				///
				///
				/// collum x - 0 only (rest is further down)
				/// 
				/// 

				if (x == 0 && z == 1) { //__________________________________________________________________________________________________________//select initial room
					int pickRoom = Random.Range (0, 3);
					int pickRoomType = Random.Range (0, 3);
					switch (pickRoom) {
					case 0:
						switch (pickRoomType) {
						case 0:
							GameObject room_NE = Instantiate (roomNE, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_NE.transform.parent = this.gameObject.transform;
							rooms.Add (room_NE);
							room_NE.name = ("start");
							break;
						case 1:
							GameObject room_NE2 = Instantiate (roomNE2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_NE2.transform.parent = this.gameObject.transform;
							rooms.Add (room_NE2);
							room_NE2.name = ("start");
							break;
						case 2:
							GameObject room_NE3 = Instantiate (roomNE3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_NE3.transform.parent = this.gameObject.transform;
							rooms.Add (room_NE3);
							room_NE3.name = ("start");
							break;
						}
						break;
					case 1:
						switch (pickRoomType) {
						case 0:
							GameObject room_N = Instantiate (roomN, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_N.transform.parent = this.gameObject.transform;
							rooms.Add (room_N);
							room_N.name = ("start");
							break;
						case 1:
							GameObject room_N2 = Instantiate (roomN2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_N2.transform.parent = this.gameObject.transform;
							rooms.Add (room_N2);
							room_N2.name = ("start");
							break;
						case 2:
							GameObject room_N3 = Instantiate (roomN3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_N3.transform.parent = this.gameObject.transform;
							rooms.Add (room_N3);
							room_N3.name = ("start");
							break;
						}
						break;
					case 2:
						switch (pickRoomType) {
						case 0:
							GameObject room_E = Instantiate (roomE, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_E.transform.parent = this.gameObject.transform;
							rooms.Add (room_E);
							room_E.name = ("start");
							break;
						case 1:
							GameObject room_E2 = Instantiate (roomE2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_E2.transform.parent = this.gameObject.transform;
							rooms.Add (room_E2);
							room_E2.name = ("start");
							break;
						case 2:
							GameObject room_E3 = Instantiate (roomE3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_E3.transform.parent = this.gameObject.transform;
							rooms.Add (room_E3);
							room_E3.name = ("start");
							break;
						}
						break;
					}
				} else if (x == 0 && rooms [((z + (x * 10)) - 2)].GetComponent<room> ().northHallway == true) { //__________________________________//select remainder of first collum of rooms (along x coordinate)
					if (z != 10) { //___________________________________________________________________________________________________________//as long as z isn't 10, it can pick from 3 different rooms
						int pickRoom = Random.Range (0, 3);
						int pickRoomType = Random.Range (0, 3);
						switch (pickRoom) {
						case 0:
							switch (pickRoomType) {
							case 0:
								GameObject room_NES = Instantiate (roomNES, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NES.transform.parent = this.gameObject.transform;
								rooms.Add (room_NES);
								room_NES.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NES2 = Instantiate (roomNES2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NES2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NES2);
								room_NES2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NES3 = Instantiate (roomNES3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NES3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NES3);
								room_NES3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 1:
							switch (pickRoomType) {
							case 0:
								GameObject room_NS = Instantiate (roomNS, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NS.transform.parent = this.gameObject.transform;
								rooms.Add (room_NS);
								room_NS.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NS2 = Instantiate (roomNS2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NS2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NS2);
								room_NS2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NS3 = Instantiate (roomNS3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NS3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NS3);
								room_NS3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 2:
							switch (pickRoomType) {
							case 0:
								GameObject room_ES = Instantiate (roomES, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ES.transform.parent = this.gameObject.transform;
								rooms.Add (room_ES);
								room_ES.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_ES2 = Instantiate (roomES2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ES2.transform.parent = this.gameObject.transform;
								rooms.Add (room_ES2);
								room_ES2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_ES3 = Instantiate (roomES3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ES3.transform.parent = this.gameObject.transform;
								rooms.Add (room_ES3);
								room_ES3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						}
					} else { //__________________________________________________________________________________________//if z is 10, it will not allow a room that goes further up along the x coordinate (north)
						int pickRoomType = Random.Range (0, 3);
						switch (pickRoomType) {
						case 0:
							GameObject room_ES = Instantiate (roomES, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_ES.transform.parent = this.gameObject.transform;
							rooms.Add (room_ES);
							room_ES.name = ("" + (rooms.Count - 1));
							break;
						case 1:
							GameObject room_ES2 = Instantiate (roomES2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_ES2.transform.parent = this.gameObject.transform;
							rooms.Add (room_ES2);
							room_ES2.name = ("" + (rooms.Count - 1));
							break;
						case 2:
							GameObject room_ES3 = Instantiate (roomES3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_ES3.transform.parent = this.gameObject.transform;
							rooms.Add (room_ES3);
							room_ES3.name = ("" + (rooms.Count - 1));
							break;
						}
					}
				} else if (x == 0 && z >= 2 && rooms [((z + (x * 10)) - 2)].GetComponent<room> ().northHallway == false) {//__________//if the previous room didn't have a hallway going north, use empty (null) room now.
					
					GameObject room_empty = Instantiate (roomEmpty, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
					room_empty.transform.parent = this.gameObject.transform;
					rooms.Add (room_empty);
					room_empty.name = ("empty");
				}

				//collum 0 end
				//////////////////////////////////////////////////////////////////////////////////////////////////////////
				///
				/// Collums beyond x - 0
				///
				/////////////////////////////////////////////////////////////////////////////////////////////////////////

				else if (x > 0 && z == 1) {
					if (rooms [((z + (x * 10)) - 11)].GetComponent<room> ().eastHallway == false) {
						GameObject room_empty = Instantiate (roomEmpty, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
						room_empty.transform.parent = this.gameObject.transform;
						rooms.Add (room_empty);
						room_empty.name = ("empty");
					} else {
						int pickRoomType = Random.Range (0, 3);
						switch (pickRoomType) {
						case 0:
							GameObject room_NEW = Instantiate (roomNEW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_NEW.transform.parent = this.gameObject.transform;
							rooms.Add (room_NEW);
							room_NEW.name = ("" + (rooms.Count - 1));
							break;
						case 1:
							GameObject room_NEW2 = Instantiate (roomNEW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_NEW2.transform.parent = this.gameObject.transform;
							rooms.Add (room_NEW2);
							room_NEW2.name = ("" + (rooms.Count - 1));
							break;
						case 2:
							GameObject room_NEW3 = Instantiate (roomNEW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
							room_NEW3.transform.parent = this.gameObject.transform;
							rooms.Add (room_NEW3);
							room_NEW3.name = ("" + (rooms.Count - 1));
							break;
						}
					}
				} else if (x > 0 && z > 1) {
					if (rooms [((z + (x * 10)) - 2)].GetComponent<room> ().northHallway == true && rooms [((z + (x * 10)) - 11)].GetComponent<room> ().eastHallway == true) {
						int pickRoom = Random.Range (0, 3);
						int pickRoomType = Random.Range (0, 3);
						switch (pickRoom) {
						case 0:
							switch (pickRoomType) {
							case 0:
								GameObject room_NESW = Instantiate (roomNESW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NESW.transform.parent = this.gameObject.transform;
								rooms.Add (room_NESW);
								room_NESW.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NESW2 = Instantiate (roomNESW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NESW2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NESW2);
								room_NESW2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NESW3 = Instantiate (roomNESW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NESW3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NESW3);
								room_NESW3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 1:
							switch (pickRoomType) {
							case 0:
								GameObject room_NSW = Instantiate (roomNSW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NSW.transform.parent = this.gameObject.transform;
								rooms.Add (room_NSW);
								room_NSW.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NSW2 = Instantiate (roomNSW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NSW2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NSW2);
								room_NSW2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NSW3 = Instantiate (roomNSW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NSW3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NSW3);
								room_NSW3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 2:
							switch (pickRoomType) {
							case 0:
								GameObject room_ESW = Instantiate (roomESW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ESW.transform.parent = this.gameObject.transform;
								rooms.Add (room_ESW);
								room_ESW.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_ESW2 = Instantiate (roomESW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ESW2.transform.parent = this.gameObject.transform;
								rooms.Add (room_ESW2);
								room_ESW2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_ESW3 = Instantiate (roomESW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ESW3.transform.parent = this.gameObject.transform;
								rooms.Add (room_ESW3);
								room_ESW3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						}
					} else if (rooms [((z + (x * 10)) - 2)].GetComponent<room> ().northHallway == true && rooms [((z + (x * 10)) - 11)].GetComponent<room> ().eastHallway == false) {
						int pickRoom = Random.Range (0, 3);
						int pickRoomType = Random.Range (0, 3);
						switch (pickRoom) {
						case 0:
							switch (pickRoomType) {
							case 0:
								GameObject room_NES = Instantiate (roomNES, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NES.transform.parent = this.gameObject.transform;
								rooms.Add (room_NES);
								room_NES.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NES2 = Instantiate (roomNES2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NES2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NES2);
								room_NES2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NES3 = Instantiate (roomNES3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NES3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NES3);
								room_NES3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 1:
							switch (pickRoomType) {
							case 0:
								GameObject room_NS = Instantiate (roomNS, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NS.transform.parent = this.gameObject.transform;
								rooms.Add (room_NS);
								room_NS.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NS2 = Instantiate (roomNS2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NS2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NS2);
								room_NS2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NS3 = Instantiate (roomNS3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NS3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NS3);
								room_NS3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 2:
							switch (pickRoomType) {
							case 0:
								GameObject room_ES = Instantiate (roomES, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ES.transform.parent = this.gameObject.transform;
								rooms.Add (room_ES);
								room_ES.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_ES2 = Instantiate (roomES2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ES2.transform.parent = this.gameObject.transform;
								rooms.Add (room_ES2);
								room_ES2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_ES3 = Instantiate (roomES3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_ES3.transform.parent = this.gameObject.transform;
								rooms.Add (room_ES3);
								room_ES3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						}
					} else if (rooms [((z + (x * 10)) - 2)].GetComponent<room> ().northHallway == false && rooms [((z + (x * 10)) - 11)].GetComponent<room> ().eastHallway == true) {
						int pickRoom = Random.Range (0, 3);
						int pickRoomType = Random.Range (0, 3);
						switch (pickRoom) {
						case 0:
							switch (pickRoomType) {
							case 0:
								GameObject room_NEW = Instantiate (roomNEW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NEW.transform.parent = this.gameObject.transform;
								rooms.Add (room_NEW);
								room_NEW.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NEW2 = Instantiate (roomNEW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NEW2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NEW2);
								room_NEW2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NEW3 = Instantiate (roomNEW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NEW3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NEW3);
								room_NEW3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						case 1:
							switch (pickRoomType) {
							case 0:
								GameObject room_NW = Instantiate (roomNW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NW.transform.parent = this.gameObject.transform;
								rooms.Add (room_NW);
								room_NW.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_NW2 = Instantiate (roomNW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NW2.transform.parent = this.gameObject.transform;
								rooms.Add (room_NW2);
								room_NW2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_NW3 = Instantiate (roomNW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_NW3.transform.parent = this.gameObject.transform;
								rooms.Add (room_NW3);
								room_NW3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;

						case 2:
							switch (pickRoomType) {
							case 0:
								GameObject room_EW = Instantiate (roomEW, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_EW.transform.parent = this.gameObject.transform;
								rooms.Add (room_EW);
								room_EW.name = ("" + (rooms.Count - 1));
								break;
							case 1:
								GameObject room_EW2 = Instantiate (roomEW2, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_EW2.transform.parent = this.gameObject.transform;
								rooms.Add (room_EW2);
								room_EW2.name = ("" + (rooms.Count - 1));
								break;
							case 2:
								GameObject room_EW3 = Instantiate (roomEW3, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
								room_EW3.transform.parent = this.gameObject.transform;
								rooms.Add (room_EW3);
								room_EW3.name = ("" + (rooms.Count - 1));
								break;
							}
							break;
						}
					} else if (rooms [((z + (x * 10)) - 2)].GetComponent<room> ().northHallway == false && rooms [((z + (x * 10)) - 11)].GetComponent<room> ().eastHallway == false) {
						GameObject room_empty = Instantiate (roomEmpty, new Vector3 ((x * offsetX), 0, (z * offsetZ)), Quaternion.identity) as GameObject;
						room_empty.transform.parent = this.gameObject.transform;
						rooms.Add (room_empty);
						room_empty.name = ("empty");
					}
				}
			}
		}
	}

	/// <summary>
	/// Finds the last room in the dungeon (furthest up the X-axis, THEN the Z-axis)
	/// Last non-"empty" room, and names it "exit"
	/// </summary>
	void FindLastRoom () {
		int index = rooms.Count;
		while(rooms[index-1].gameObject.name == "empty") {
			index -= 1;
		}
		rooms[index-1].gameObject.name = "exit";

		///
		///add trigger to exit level and go to the next
		///
	}
}
