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
		if(temp){
			StartCoroutine ("eBlinker");
			temp = false;
		}
	}

	IEnumerator eBlinker(){
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
		yield return new WaitForSeconds (nonTransDuration);

		eColor.a = 0;
		GetComponent<Image> ().color = eColor;
		yield return new WaitForSeconds (transDuration);

		eColor.a = 255;
		GetComponent<Image> ().color = eColor;

		StopCoroutine ("eBlinker");
	}
}