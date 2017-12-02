using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basics : MonoBehaviour {

	// Learn Variables (One Line Comment) 

	/*
	 * Mutiple
	 * Line
	 * Comment
	 */

	int patriots = 34;
	int falcons = 28;
	float speed = 2.5f;
	string result = "The Refs were paid!";
	bool isDead = true;

	// Use this for initialization
	void Start () {

		// Operators =, +, -, *, and / can be used to perform calculations
		// Debug.Log("Patriots = " + patriots + " " + "Falcons = " + falcons + " " + result);

		// int random = Random.Range (10, 70);
		// Debug.Log (random);

		// PrintSomething();
		// Debug.Log (AddUp (5,15));

		if (isDead) /* logical test */ {  
			Debug.Log ("The logical test is true!");
			// stuff that happens when logical test is true - 1
		} 
	
		else {
			Debug.Log ("The logical test is false!");
			// stuff that happens when logical test is false - 0
		}

		int num = 0;
		// looping
		while(num <= 5) /* as long as num is less than 5, loop this action */ {
			Debug.Log ("Repeat num = " + num);
			num = num + 1; // Real C# wizards will use num++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	// function definitions
	void PrintSomething() {
		Debug.Log ("I am running the PrintSomething function!" + " " + AddUp(2,5) + " " + Mutiply(2,5));	
	}

	int AddUp(int a, int b){
		return a + b;
	}

	int Mutiply(int a, int b){
		return a * b;
	}
}
