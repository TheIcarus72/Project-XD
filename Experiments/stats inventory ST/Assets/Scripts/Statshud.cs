using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Statshud : MonoBehaviour {

	public Canvas stats;
	public Inventory inventoryScript;
	public PlayerScript playerScript;
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

	public int energy;
	public int maxEnergy;
	public GameObject energyText;

	public int healthRegen;
	public GameObject healthRegenText;

	public int energyRegen;
	public GameObject energyRegenText;

	public int speed;
	public GameObject speedText;

	public int weight;
	public int maxWeight;
	public GameObject weightText;

	public GameObject inGameHealthText;
	public GameObject inGameEnergyText;
	public int ammoAmount = 20;
	public GameObject ammo;
	public GameObject inGameAmmoText;

	// Use this for initialization
	void Start () {
		// gives acces to canvas component
		stats = stats.GetComponent<Canvas> ();
		stats.gameObject.SetActive (false);

		SwitchToNull ();

	}

	// Update is called once per frame
	void Update () {
		//When key 'f' is pressed, activate stats canvas, dissable movement
		if(Input.GetKeyDown("f")){
			if (inventoryScript.inventoryShowing == false) {
				statsHudShowing = !statsHudShowing;
				playerScript.movementEnabled = false;
			}
		}
		//When the escape key is pressed, deactivate stats canvas, enable movement
		if(Input.GetKeyDown("escape") && statsHudShowing){
			statsHudShowing = !statsHudShowing;
			playerScript.movementEnabled = true;
		}

		if (stats.gameObject.activeInHierarchy == true && changeToStats) {
			statsUpdate();
		}

		if (statsHudShowing) {
			stats.gameObject.SetActive (true);
		} else {
			stats.gameObject.SetActive (false);
		}

		statsUpdate ();

		//testing purpose only
		if (statsHudShowing == false && inventoryScript.inventoryShowing == false) {
			// remove this, testing purpose only:
			if (Input.GetKeyDown ("1")) {
				SwitchToGun ();
			}

			// remove this, testing purpose only:
			if (Input.GetKeyDown ("2")) {
				SwitchToSword ();
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
		LVLtext.text = playerLevel.ToString();

		Text Htext = healthText.GetComponent<Text> ();
		Htext.text = health.ToString() + " / " + maxHealth.ToString();

		Text Etext = energyText.GetComponent<Text> ();
		Etext.text = energy.ToString() + " / " + maxEnergy.ToString();

		Text HRtext = healthRegenText.GetComponent<Text> ();
		HRtext.text = "LVL. " + healthRegen.ToString();

		Text ERtext = energyRegenText.GetComponent<Text> ();
		ERtext.text = "LVL. " + energyRegen.ToString();

		Text Stext = speedText.GetComponent<Text> ();
		Stext.text = "LVL. " + speed.ToString();

		Text Wtext = weightText.GetComponent<Text> ();
		Wtext.text = weight.ToString() + " / " + maxWeight.ToString();


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
}
