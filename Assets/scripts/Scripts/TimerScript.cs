using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerScript : MonoBehaviour {

	private Slider slider;
	private GameObject player;
	public float time = 150f;  //this sets the starting time
	private float timeBurn = 1f;  //this sets the increment of countdown


	// Use this for initialization
	void Awake () {
		GetReferences ();
	}

	// Update is called once per frame
	void Update () {
		if (!player) {  //if no player is found jump out of this function
			return;
		}
		if (time > 0) {        //if there are still seconds left on the timer...
			time -= timeBurn * Time.deltaTime; //subtract timeBurn from the current time left
			slider.value = time;  //this associates the time remaining to the graphical slider
		} else {
			// otherwise if there is no time left on the timer, run the SetPlayerState function in the PlayerScript(this kills the player)
			player.gameObject.GetComponent<PlayerScript>().ImDead();
		}
	}
	//This function sets all of the initial variables
	void GetReferences(){
		player = GameObject.Find ("Player");  //this corresponds to the name of your player object
		slider = GameObject.Find ("timer slider").GetComponent<Slider>(); //this corresponds to the name of your time slider object
		slider.minValue = 0f;
		slider.maxValue = time;
		slider.value = slider.maxValue;

	}

}

