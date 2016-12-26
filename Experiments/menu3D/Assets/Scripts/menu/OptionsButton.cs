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
		
		if (optionsPressed) {
			camera.transform.Translate (0.31f * cameraSpeed, 0.01f * cameraSpeed, 0.1f * cameraSpeed);
			//print ("pressed");
			if (camera.transform.position.x >= 1.0f) {
				optionsPressed = false;

			}
		}

		if (backPressed) {
			camera.transform.Translate (-0.31f * cameraSpeed, -0.01f * cameraSpeed, -0.1f * cameraSpeed);
			if (camera.transform.position.x <= -3.0f) {
				backPressed = false;
				//print ("destination");
			}
		}
	}
	
	void OnMouseDown(){
		if(this.gameObject.tag == "options"){
			optionsPressed = true;
			gameController.inOptions = true;
			//Vector3(-1.2f, 0.05f, 0.41f), new Vector3(0.62f, 0.09f, 0.41f);
		}
		if (this.gameObject.tag == "back") {
			backPressed = true;
			gameController.inOptions = false;
		}
	}

	void OnMouseEnter(){
		gameObject.GetComponent<TextMesh> ().color = Color.cyan;
	}

	void OnMouseExit(){
		gameObject.GetComponent<TextMesh> ().color = Color.white;
	}
}
