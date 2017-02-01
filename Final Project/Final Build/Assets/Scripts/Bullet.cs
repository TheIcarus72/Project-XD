using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	Vector3 bulletTarget = new Vector3(0f,0f,0f);
	//int layer = 1 << 8;
	// Use this for initialization
	void Start () {
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(x,y,0));
		if(Physics.Raycast(ray, out hit,Mathf.Infinity)){
			bulletTarget = hit.point;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(bulletTarget);
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
	void OnTriggerEnter (Collider col) {
		Destroy (this.gameObject);
	}
}
