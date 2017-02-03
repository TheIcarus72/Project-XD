using System.Collections;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	//Quit game on exit press
	void OnMouseDown(){
		Application.Quit ();
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
