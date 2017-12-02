using UnityEngine;
using System.Collections;

public class EnemyGunner : MonoBehaviour {

	[SerializeField]
	private GameObject Bullet;
	bool attack;
	Rigidbody2D myRigidbody2D; 
	// Use this for initialization
	void Start () {
		//this calls our attack function to start shooting the myBullets right from the start of the game.
		StartCoroutine (Attack2 ());
		//myBullet = GameObject.FindGameObjectWithTag ("myBullet");
		//myRigidbody2D = myBullet.GetComponent<Rigidbody2D> (); 
	}


	IEnumerator Attack2 (){
		yield return new WaitForSeconds (Random.Range (1, 3));
		Instantiate (Bullet, transform.position, Quaternion.identity);
		//myRigidbody2D.velocity = (Vector2.left * 10); 
		//myRigidbody2D.gravityScale = 0; 
		//this begins the coroutine
		StartCoroutine (Attack2 ());
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Player") {
			Destroy (target.gameObject);
		}

	}
}