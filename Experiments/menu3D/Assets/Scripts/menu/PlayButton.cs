using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
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
