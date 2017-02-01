using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class elevator : MonoBehaviour {
	public GameObject doorPrefab;
	public GameObject countDownTextObject;
	public float count;
	float timer;
	Text countText;
	public float maximumHeight;
	bool enteredElevator = false;


	// Use this for initialization
	// set timer to 5 sec, deactivate timerText(only needed in elevator)
	void Start () {
		timer = 5f;
		countText = countDownTextObject.GetComponent<Text> ();
		countDownTextObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//close elevator door
		if (enteredElevator == true) {
			doorPrefab.transform.Translate(Vector3.up * 2 * Time.deltaTime);

			// stops closing when maximum height is achieved
			if (doorPrefab.transform.position.y >= maximumHeight) {
				enteredElevator = false;
				countDownTextObject.SetActive (true);
			}
		}

		//start countdown timer when the door is closed, set the timer to a round int (else the time on the screen would look like: 1.263643187).
		if (doorPrefab.transform.position.y >= maximumHeight) {
			timer -= Time.deltaTime;
			count = Mathf.FloorToInt (timer);
		}

		//print countdown time on screen
		countText.text = count.ToString ();

		//load new scene when countdown is done
		if(timer < 0){
			SceneManager.LoadScene (2);
		}


	}

	//when the player enters the trigger and has not entered the elevator(trigger) before, bool = true
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "dialogePicker" && enteredElevator == false){
			enteredElevator = true;
		}
	}
}
