using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthBlinker : MonoBehaviour {
	public float transDuration;
	public float nonTransDuration;

	private Color hColor;
	bool temp = true;

	// Use this for initialization
	void Start () {
		hColor = GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	// needs to be changed to:  when damage is taken, start coroutine
	void Update () {
		if(temp){
			StartCoroutine ("hBlinker");
			temp = false;
		}
	}

	IEnumerator hBlinker(){
		hColor.a = 0;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (transDuration);

		hColor.a = 255;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (nonTransDuration);

		hColor.a = 0;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (transDuration);

		hColor.a = 255;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (nonTransDuration);

		hColor.a = 0;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (transDuration);

		hColor.a = 255;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (nonTransDuration);

		hColor.a = 0;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (transDuration);

		hColor.a = 255;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (nonTransDuration);

		hColor.a = 0;
		GetComponent<Image> ().color = hColor;
		yield return new WaitForSeconds (transDuration);

		hColor.a = 255;
		GetComponent<Image> ().color = hColor;

		StopCoroutine ("hBlinker");
	}
}
