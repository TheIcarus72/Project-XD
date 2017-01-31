using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {
	
	void OnMouseDown(){
		SceneManager.LoadScene (1);
	}

	void OnMouseEnter(){
		gameObject.GetComponent<TextMesh> ().color = Color.cyan;
	}

	void OnMouseExit(){
		gameObject.GetComponent<TextMesh> ().color = Color.white;
	}
}
