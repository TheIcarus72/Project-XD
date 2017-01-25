using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Statshud : MonoBehaviour {

	public Canvas stats;
	public Inventory inventoryScript;
	public CharacterControl characterControl;
	public MainCharacterVariables mainCharacterVariables;
	private bool changeToStats = false;
	public bool statsHudShowing = false;
	bool equipSword;
	bool equipGun;
	bool equipNull;

	public int playerLevel;
	public GameObject playerLevelText;

	public int pointsAvailable;
	public GameObject pointsAvailableText;

	public int health;
	public int maxHealth;
	public GameObject healthText;

	public float energy;
	public int maxEnergy;
	public GameObject energyText;

	public float healthRegen;
	public GameObject healthRegenText;

	public float energyRegen;
	public GameObject energyRegenText;

	public GameObject inGameHealthText;
	public GameObject inGameEnergyText;
	public int ammoAmount = 20;
	public GameObject ammo;
	public GameObject inGameAmmoText;

	public GameObject guideFText;

	public GameObject HPlus;
	public GameObject HrPlus;
	public GameObject EPlus;
	public GameObject ErPlus;
	bool eRegenerating = false;

	// Use this for initialization
	void Start () {
		// gives acces to canvas component
		stats = stats.GetComponent<Canvas> ();
		stats.gameObject.SetActive (false);

		SwitchToNull ();

	}

	IEnumerator EnergyRegeneration(){
		yield return new WaitForSeconds (5);
		while (energy < maxEnergy) {
			eRegenerating = true;
			energy = energy + energyRegen;
			yield return new WaitForSeconds (10);
		}
	}

	// Update is called once per frame
	void Update () {
		// regen energy
		if (energy > maxEnergy) {
			energy = maxEnergy;
			eRegenerating = false;
		}
		if (energy < maxEnergy && eRegenerating == false) {
			StartCoroutine("EnergyRegeneration");
		}

		//deactivate skill plusses when max level is reached
		if(playerLevel >= 5){
			HPlus.SetActive (false);
			HrPlus.SetActive (false);
			EPlus.SetActive (false);
			ErPlus.SetActive (false);
		}

		//When key 'f' is pressed, activate stats canvas, dissable movement
		if(Input.GetKeyDown("f") && !Input.GetKey("w")){
			if (inventoryScript.inventoryShowing == false) {
				statsHudShowing = !statsHudShowing;
				characterControl.movementEnabled = !characterControl.movementEnabled;
				mainCharacterVariables.movementEnabled = !mainCharacterVariables.movementEnabled;
				guideFText.SetActive (false);
			}
		}
		//When the escape key is pressed, deactivate stats canvas, enable movement
		if(Input.GetKeyDown("escape") && statsHudShowing){
			statsHudShowing = !statsHudShowing;
			characterControl.movementEnabled = true;
			mainCharacterVariables.movementEnabled = true;
		}

		if (stats.gameObject.activeInHierarchy == true && changeToStats) {
			statsUpdate();
		}

		if (statsHudShowing) {
			stats.gameObject.SetActive (true);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		} else {
			stats.gameObject.SetActive (false);
			Cursor.visible = false;
		}

		statsUpdate ();

		//testing purpose only
		if (statsHudShowing == false && inventoryScript.inventoryShowing == false) {
			// remove this, testing purpose only:
			if (Input.GetKeyDown ("1")) {
				if (equipSword == true)
					SwitchToNull ();
				else
					SwitchToSword ();
			}

			// remove this, testing purpose only:
			if (Input.GetKeyDown ("2")) {
				if (equipGun == true)
					SwitchToNull ();
				else
					SwitchToGun ();
			}

			// remove this, testing purpose only:
			if (Input.GetKeyDown ("3")) {
				SwitchToNull ();
			}
		}
	}

	// call this function if you switch to a gun
	void SwitchToGun(){
		equipGun = true;
		equipSword = false;
		equipNull = false;

		ammo.gameObject.SetActive (true);
		ammo.GetComponent<Image> ().overrideSprite = Resources.Load<Sprite> ("gunUI");
	}

	// call this function if you switch to a sword
	void SwitchToSword(){
		equipGun = false;
		equipSword = true;
		equipNull = false;

		ammo.gameObject.SetActive (true);
		ammo.GetComponent<Image> ().overrideSprite = Resources.Load<Sprite> ("swordUI");
	}

	// call this function if you switch to empty hands
	void SwitchToNull(){
		equipGun = false;
		equipSword = false;
		equipNull = true;

		ammo.gameObject.SetActive (false);
	}

	// updating the text of the statistics
	void statsUpdate(){
		Text PAtext = pointsAvailableText.GetComponent<Text> ();
		PAtext.text = pointsAvailable.ToString();

		Text LVLtext = playerLevelText.GetComponent<Text> ();
		LVLtext.text = playerLevel.ToString() + " / 5";

		Text Htext = healthText.GetComponent<Text> ();
		Htext.text = health.ToString() + " / " + maxHealth.ToString();

		Text Etext = energyText.GetComponent<Text> ();
		Etext.text = energy.ToString() + " / " + maxEnergy.ToString();

		Text HRtext = healthRegenText.GetComponent<Text> ();
		HRtext.text = "x " + healthRegen.ToString();

		Text ERtext = energyRegenText.GetComponent<Text> ();
		ERtext.text = "x " + energyRegen.ToString();


		//inGameTexts
		Text IGHtext = inGameHealthText.GetComponent<Text> ();
		IGHtext.text = health.ToString() + " / " + maxHealth.ToString();

		Text IGEtext = inGameEnergyText.GetComponent<Text> ();
		IGEtext.text = energy.ToString() + " / " + maxEnergy.ToString();

		if (equipGun) {
			Text IGAtext = inGameAmmoText.GetComponent<Text> ();
			IGAtext.text = ammoAmount.ToString ();
		}

		if (equipSword) {
			Text IGAtext = inGameAmmoText.GetComponent<Text> ();
			IGAtext.text = " ";
		}
	}

	public void OnHPlus(){
		pointsAvailable--;
		playerLevel++;
		maxHealth = maxHealth + 25;
	}

	/*public void OnHrPlus(){
		pointsAvailable--;
		energyRegen = energyRegen + 0.1f;
	}*/

	public void OnEPlus(){
		pointsAvailable--;
		playerLevel++;
		maxEnergy = maxEnergy + 25;
	}

	public void OnErPlus(){
		pointsAvailable--;
		playerLevel++;
		energyRegen = energyRegen + 0.5f;
	}
}
