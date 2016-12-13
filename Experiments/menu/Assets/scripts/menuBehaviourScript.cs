using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuBehaviourScript : MonoBehaviour {

	//public Canvas quitMenu;
	public Button startText;
	public Button creditsText;
	public Button quitText;
	public GameObject quitMenu;
	public GameObject credits;
	public Button yesText;
	public Button noText;

	// Use this for initialization
	void Start () {
		// gives acces to button component
		startText = startText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
		creditsText = creditsText.GetComponent<Button> ();
		yesText = yesText.GetComponent<Button> ();
		noText = noText.GetComponent<Button> ();

		// disables quitMenu
		quitMenu.gameObject.SetActive (false);
		credits.gameObject.SetActive (false);

	}

	// loads the game
	public void startGame(){
		SceneManager.LoadScene (1);
	}

	// When exit is pressed, enable quitMenu
	public void ExitPress(){
		quitMenu.gameObject.SetActive (true);
	}

	// if pressed on 'no' button, dissables quitMenu, enables mainMenu
	public void NoPress(){
		quitMenu.gameObject.SetActive (false);
	}

	// quits game on pressing 'yes' button
	public void quitGame(){
		Application.Quit ();
	}


	// start the animation of the credits panel
	public void CreditsPress(){
		credits.gameObject.SetActive (true);
		StartCoroutine (creditTimer());
	}

	// deactivates creditpanel after 9 sec
	IEnumerator creditTimer(){
		yield return new WaitForSeconds (9);
		credits.gameObject.SetActive (false);
		StopCoroutine (creditTimer());
	}


}
