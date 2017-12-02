using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	//variables

	private Rigidbody2D myRigidbody;

	public Animator myAnimator;

	public float movementSpeed;

	private bool facingRight;

	public GameObject reset;

	[SerializeField] // Forces unity to serialize a private field
	private Transform[] groundPoints; //creates something to collide with the ground

	[SerializeField]
	private float groundRadius;//creates the size of the colliders

	[SerializeField]
	private LayerMask whatIsGround;//defines what is ground

	private bool isGrounded;//can be set to true or false based on our position

	private bool jump;//can be set to true or false when we press the space key

	[SerializeField]
	private float jumpForce;//allows us to determine the magnitude of the jump

	public bool isAlive;

	private Slider healthBar;
	public float health = 10f;
	private float healthBurn = 5f;
	private float instantBurn = 10f;

	// Use this for initialization
	void Start () {

		//associates the new variable myRigidbody with the Rigidbody2D component
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator> ();
		facingRight = true;
		isAlive = true;
		reset.gameObject.SetActive (false);
		healthBar = GameObject.Find ("health slider").GetComponent<Slider>();
		healthBar.minValue = 0f;
		healthBar.maxValue = health; 
		healthBar.value = healthBar.maxValue;
	}

	// This function will be called when a player collides with an enemy
	public void UpdateHealth(){
		if (health > 0) {
			// if health bar has life left..
			health -= healthBurn; // current value of health minus 5f
			healthBar.value = health; // update the interface slider
		} 
		if (health <= 0) {
			ImDead (); // If no life, run this function
		}
	}
	// Update is called once per frame
	void Update(){
		HandleInput ();

	}


	void FixedUpdate () {

		//a variable to access the keyboard controls and move the player left and right
		float horizontal = Input.GetAxis("Horizontal");
		//Debug.Log (horizontal);
		if (isAlive) {
			HandleMovement (horizontal);
			Flip (horizontal);
		} else {
			return;
		}
		isGrounded = IsGrounded ();
	}

	//my function definitions go here
	private void HandleMovement(float horizontal){

		if(isGrounded && jump){

			isGrounded = false;
			jump = false;
			myRigidbody.AddForce (new Vector2 (0,jumpForce));

		}

		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y );

		myAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

	private void Flip(float horizontal){

		if(horizontal<0 && facingRight || horizontal>0 && !facingRight){
			facingRight = !facingRight; //sets the bool to its opposite
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private void HandleInput(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
			//Debug.Log ("Jumping activated");
			myAnimator.SetBool ("jumping", true);
		}
	}

	private bool IsGrounded(){
		if (myRigidbody.velocity.y <= 0) {
			//if player is not moving vertically, test each of Player's groundPoints for collision with Ground
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; 1 < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;

					}
				}
			}
		}
		return false;
	}

	public void ImDead(){
		myAnimator.SetBool ("dead", true);
		isAlive = false;
		Debug.Log ("GameOVER");
		reset.gameObject.SetActive (true);
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Ground") {

			myAnimator.SetBool ("jumping", false);
		}

		// this is added to kill the player
		if (target.gameObject.tag == "damage") {
			UpdateHealth ();
		}


		if (target.gameObject.tag == "deadly" || target.gameObject.tag == "Bullet" || target.gameObject.tag == "Bullet 2") {
			//gameObject.GetComponent<Collider2D>().enabled = false;
			ImDead ();
			UpdateHealth ();
			health -= instantBurn; // current value of health minus 5f
			healthBar.value = health; // update the interface slider
		}
	}
}

