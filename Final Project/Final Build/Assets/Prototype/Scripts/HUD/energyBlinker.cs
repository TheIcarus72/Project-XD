using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class energyBlinker : MonoBehaviour {
	public float transDuration;
	public float nonTransDuration;

	private Color eColor;
	bool temp = true;

	// Use this for initialization
	void Start () {
		eColor = GetComponent<Image> ().color;
	}

	// Update is called once per frame
	// needs to be changed to:  when energy is used, start coroutine
	void Update () {
		//calls coroutine once, can be called from another script to enableit once again.
		if(temp){
			StartCoroutine ("eBlinker");
			temp = false;
		}
	}

	IEnumerator eBlinker(){
		//makes the sprite invisible for a certain amount of time
		//needs getcomponent everytime it changes to apply it ingame
		eColor.a = 0;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (transDuration);

		//makes sprite visible for a certain amount of time
		eColor.a = 255;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (nonTransDuration);

		eColor.a = 0;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (transDuration);

		eColor.a = 255;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (nonTransDuration);

		eColor.a = 0;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (transDuration);

		eColor.a = 255;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (nonTransDuration);

		eColor.a = 0;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (transDuration);

		eColor.a = 255;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (nonTransDuration);

		eColor.a = 0;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (transDuration);

		eColor.a = 255;
		GetComponent<Image> ().color = eColor;

		//stop this coroutine
		StopCoroutine ("eBlinker");
	}
}