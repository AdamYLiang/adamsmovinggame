﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			//Loads main game scene if pressed
			//Dont use application.loadlevel, its getting phased out, new thing
			//If crossed out it means its slowly starting to dip
			//Add UnityEngine.SceneManagement
			SceneManager.LoadScene(1);
		}
	}
}
