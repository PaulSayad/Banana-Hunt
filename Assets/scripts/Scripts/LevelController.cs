using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public void Lvl1(){
		SceneManager.LoadScene ("Level1");
	}

	public void Lvl2(){
		SceneManager.LoadScene ("Level2");
	}

}