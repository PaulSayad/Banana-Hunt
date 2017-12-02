using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelController : MonoBehaviour {

	public void Lvl1(){
		SceneManager.LoadScene ("Level2");
	}

	public void Lvl2(){
		SceneManager.LoadScene ("Level1");
	}

}