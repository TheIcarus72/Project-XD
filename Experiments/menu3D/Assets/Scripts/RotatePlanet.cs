using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f *Time.deltaTime, 1f *Time.deltaTime * speed, 0f *Time.deltaTime, Space.Self);
	}
}
