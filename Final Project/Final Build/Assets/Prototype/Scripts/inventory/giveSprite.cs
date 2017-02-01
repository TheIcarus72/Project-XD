using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class giveSprite : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpriteB(int id, string slug){
		Sprite sprite = Resources.Load<Sprite> (slug) as Sprite;
	}
}
