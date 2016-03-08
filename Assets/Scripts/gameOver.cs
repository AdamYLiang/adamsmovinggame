using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	public Text gameText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameLogic.winGame == true) {

			gameText.text = "You won! \n Press [R] to restart!";

			if (Input.GetKeyDown (KeyCode.R)) {
				//Loads main game scene if pressed
				//Dont use application.loadlevel, its getting phased out, new thing
				//If crossed out it means its slowly starting to dip
				//Add UnityEngine.SceneManagement
				//Reloads scene
				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				gameLogic.winGame = false;
				SceneManager.LoadScene (1);
			}
			
		} else {

			gameText.text = "You fell into the water and got wet. \n Everything is ruined \n Press [R] to Retry";

			if (Input.GetKeyDown (KeyCode.R)) {
				//Loads main game scene if pressed
				//Dont use application.loadlevel, its getting phased out, new thing
				//If crossed out it means its slowly starting to dip
				//Add UnityEngine.SceneManagement
				//Reloads scene
				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);

				SceneManager.LoadScene (1);
			}

		}
}
}
