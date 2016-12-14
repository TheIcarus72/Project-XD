using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float HealthPoints = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(HealthPoints <= 0)
		{
			this.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Sword" && MainCharacterVariables.attack)
		{
			HealthPoints -= MainCharacterVariables.swordDamage;
		}
		if(col.gameObject.tag == "Bullet" && MainCharacterVariables.attack)
		{
			HealthPoints -= MainCharacterVariables.rifleDamage;
		}
	}
}
