using System.Collections;
using UnityEngine;

public class OptionsButton : MonoBehaviour {
	public GameObject camera;
	public float cameraSpeed = 1f;
	bool optionsPressed = false;
	bool backPressed = false;

	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (optionsPressed) {
			camera.transform.Translate (0.091f * cameraSpeed, 0.01f * cameraSpeed, 0.032f * cameraSpeed);
			print ("pressed");
			if (camera.transform.position.x >= 0.61f) {
				optionsPressed = false;

			}
		}

		if (backPressed) {
			camera.transform.Translate (-0.091f * cameraSpeed, -0.01f * cameraSpeed, -0.032f * cameraSpeed);
			if (camera.transform.position.x <= -1.2f) {
				backPressed = false;
				print ("destination");
			}
		}
	}
	
	void OnMouseDown(){
		if(this.gameObject.tag == "options"){
			optionsPressed = true;
			//Vector3(-1.2f, 0.05f, 0.41f), new Vector3(0.62f, 0.09f, 0.41f);
		}
		if (this.gameObject.tag == "back") {
			backPressed = true;
		}
	}

	void OnMouseEnter(){
		gameObject.GetComponent<TextMesh> ().color = Color.cyan;
	}

	void OnMouseExit(){
		gameObject.GetComponent<TextMesh> ().color = Color.white;
	}
}
