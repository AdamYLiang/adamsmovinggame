﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour {

	//Consider having it be a time attack mode
	//Where you can pick up powerups and go fast 
	//Think of the SICK combos 

	public Text hintHelp;
	public Transform player;
	public GameObject jumpBox;
	public GameObject fastBox2;
	public GameObject heavyBox;
	public GameObject winZone;
	//public GameObject elevator;
	int amountOfBoxes = 0;//Make it in the game when you hit 3 
	float displayTimer = 3f;
	float hDisplayTimer = 3f;
	float jDisplayTimer = 3f;
	float jumpTimer = 3f;
	bool hasBox = false;
	int boxType = 0;

	// Use this for initialization
	void Start () {

		//GameObject player = GameObject.Find("Player");
		//playerMovement playerMovement = player.GetComponent<playerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		string textBuffer = " ";

		//Fast moving box
		if(((player.position - fastBox2.transform.position).magnitude < 3f) &&
			fastBox2.activeSelf){

			if(!hasBox && ((player.position - winZone.transform.position).magnitude > 3f)){

			textBuffer = "Press [E] to pick up a light box";

			if(Input.GetKeyDown(KeyCode.E)){
				hasBox = true;
				boxType = 1;
				player.GetComponent<playerMovement>().hasBox = true;
				player.GetComponent<playerMovement>().boxType = "fast";

				//Dont destroy it, instead just hide it, then make it active and teleport it when you place it
				fastBox2.SetActive(false);
			}
			}

			if(hasBox){
				textBuffer = "You cannot hold more than 1 box \n Drop held box with [Q]";
			}

		}

		//Jumping box
		if(((player.position - jumpBox.transform.position).magnitude < 3f) &&
			jumpBox.activeSelf){

			if(!hasBox && ((player.position - winZone.transform.position).magnitude > 3f)){

				textBuffer = "Press [E] to pick up an energetic box";

				if(Input.GetKeyDown(KeyCode.E)){
					hasBox = true;
					boxType = 2;
					player.GetComponent<playerMovement>().hasBox = true;
					player.GetComponent<playerMovement>().boxType = "jump";

					//Dont destroy it, instead just hide it, then make it active and teleport it when you place it
					jumpBox.SetActive(false);

				}
			}

			if(hasBox && !(boxType == 2)){
				textBuffer += "You cannot hold more than 1 box \n Drop held box with [Q]";
			}

		}

		//Make thsi show up tytyt
		if(boxType == 2){
			if(jumpTimer > 0){
			textBuffer = "Press [SPACE] to jump while holding jump box";
			}
			jumpTimer -= Time.deltaTime;
		}
			

		//Heavy box
		if(((player.position - heavyBox.transform.position).magnitude < 3f) &&
			heavyBox.activeSelf){

			if(!hasBox && ((player.position - winZone.transform.position).magnitude > 3f)){

				textBuffer = "Press [E] to pick up a heavy box";

				if(Input.GetKeyDown(KeyCode.E)){
					hasBox = true;
					boxType = 3;
					player.GetComponent<playerMovement>().hasBox = true;
					player.GetComponent<playerMovement>().boxType = "heavy";

					//Dont destroy it, instead just hide it, then make it active and teleport it when you place it
					heavyBox.SetActive(false);
				}
			}

			if(hasBox){
				textBuffer = "You cannot hold more than 1 box \n Drop held box with [Q]";
			}

		}

		//Winning code
		if(((fastBox2.transform.position - winZone.transform.position).magnitude < 5f) &&
			fastBox2.activeSelf){

			if(displayTimer > 0){
				textBuffer = "Placed Fast Box in correct place";
			};

			displayTimer -= Time.deltaTime;

		}

		if(((jumpBox.transform.position - winZone.transform.position).magnitude < 5f) &&
			jumpBox.activeSelf){
		
			if(jDisplayTimer > 0){
				textBuffer = "Placed Energetic Box in correct place";
			};

			jDisplayTimer -= Time.deltaTime;

		}

		if(((heavyBox.transform.position - winZone.transform.position).magnitude < 5f) &&
			heavyBox.activeSelf){

			if(hDisplayTimer > 0){
				textBuffer = "Placed Heavy Box in correct place";
			};

			hDisplayTimer -= Time.deltaTime;

		}

		//Dropping a box
		if(hasBox && Input.GetKeyDown(KeyCode.Q)){
			if(boxType == 1){
				hasBox = false;
				boxType = 0;
				player.GetComponent<playerMovement>().hasBox = false;
				player.GetComponent<playerMovement>().boxType = "none";

				//Fix the rotation, it doesnt place it directly on where the camera is
				fastBox2.transform.position = (player.transform.position + (player.transform.forward * 2f));

				fastBox2.SetActive(true);
			}

			if(boxType == 2){
				hasBox = false;
				boxType = 0;
				player.GetComponent<playerMovement>().hasBox = false;
				player.GetComponent<playerMovement>().boxType = "none";

				//Fix the rotation, it doesnt place it directly on where the camera is
				jumpBox.transform.position = (player.transform.position + (player.transform.forward * 2f));

				jumpBox.SetActive(true);
			}

			if(boxType == 3){
				hasBox = false;
				boxType = 0;
				player.GetComponent<playerMovement>().hasBox = false;
				player.GetComponent<playerMovement>().boxType = "none";

				//Fix the rotation, it doesnt place it directly on where the camera is
				heavyBox.transform.position = (player.transform.position + (player.transform.forward * 2f));

				heavyBox.SetActive(true);
			}
		}

		//Elevator movement with heavy box
		//Add some fences from maya
		//Add a shortcut for going back 


		//Consider not doing a buffer maybe
		hintHelp.text = textBuffer;
		
	}
}
