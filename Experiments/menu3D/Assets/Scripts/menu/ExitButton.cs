using System.Collections;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnMouseDown(){
		// open panel? or quit immediately
		//Application.Quit ();
	}

	void OnMouseEnter(){
		gameObject.GetComponent<TextMesh> ().color = Color.cyan;
	}

	void OnMouseExit(){
		gameObject.GetComponent<TextMesh> ().color = Color.white;
	}
}
