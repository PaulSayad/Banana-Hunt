using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour {

	public float movementSpeed = 1;

	//This searches for a collision between our bullet and our player.  if the palyer collides with the bullet both the bullet and the player disappear
	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Player") {
			target.gameObject.GetComponent<PlayerScript> ().isAlive = false;
			target.gameObject.GetComponent<PlayerScript> ().myAnimator.SetBool("Dead", true);
			//	target.gameObject.GetComponent<PlayerScript> ().reset.SetActive(true);
			//Destroy (target.gameObject);
			Destroy (gameObject);
		}
		//this checks to see if the bullet touches the ground, then unloads the bullet if it touches ground.
		if (target.gameObject.tag == "Ground" || target.gameObject.tag == "deadly" || target.gameObject.tag == "damage" ) { 
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);	
	}
}


