using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {

	//load scene 1 on mousepress
	void OnMouseDown(){
		SceneManager.LoadScene (1);
	}

	//change text color at mouse over
	void OnMouseEnter(){
		gameObject.GetComponent<TextMesh> ().color = Color.cyan;
	}

	//change text color at mouse exit
	void OnMouseExit(){
		gameObject.GetComponent<TextMesh> ().color = Color.white;
	}
}
