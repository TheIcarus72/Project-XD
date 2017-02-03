using System.Collections;
using UnityEngine;

public class OptionsButton : MonoBehaviour {
	public GameObject character;
	public GameObject camera;
	public float cameraSpeed = 3f;
	bool optionsPressed = false;
	bool backPressed = false;
	public GameObject gameControl;
	GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = gameControl.GetComponent<GameController>();
	}

	void Update(){
		//move camera until a certain position has been reached
		if (optionsPressed) {
			camera.transform.Translate (0.31f * cameraSpeed, 0.01f * cameraSpeed, 0.1f * cameraSpeed);
			if (camera.transform.position.x >= 1.0f) {
				optionsPressed = false;

			}
		}

		//move camera until a certain position has been reached
		if (backPressed) {
			camera.transform.Translate (-0.31f * cameraSpeed, -0.01f * cameraSpeed, -0.1f * cameraSpeed);
			if (camera.transform.position.x <= -3.0f) {
				backPressed = false;
			}
		}
	}
	
	void OnMouseDown(){
		//enable cameramovement in update function
		if(this.gameObject.tag == "options"){
			optionsPressed = true;
			gameController.inOptions = true;
		}
		//enable cameramovent backwards in update function
		if (this.gameObject.tag == "back") {
			backPressed = true;
			gameController.inOptions = false;
		}
	}

	//change textcolor when mouse over
	void OnMouseEnter(){
		gameObject.GetComponent<TextMesh> ().color = Color.cyan;
	}

	//change textcolor when mouse exit
	void OnMouseExit(){
		gameObject.GetComponent<TextMesh> ().color = Color.white;
	}
}
