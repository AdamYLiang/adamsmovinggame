using UnityEngine;
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
	public Transform heavyBox;
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

		if(((player.position - fastBox2.transform.position).magnitude < 3f) &&
			fastBox2.activeSelf){

			if(!hasBox){

			textBuffer = "Press [SPACE] to pick up a light box";

			if(Input.GetKeyDown(KeyCode.Space)){
				hasBox = true;
				boxType = 1;
				player.GetComponent<playerMovement>().hasBox = true;
				player.GetComponent<playerMovement>().boxType = "fast";

				//Dont destroy it, instead just hide it, then make it active and teleport it when you place it
				fastBox2.SetActive(false);
			}
			}

			if(hasBox){
				textBuffer = "You cannot hold more than 1 box";
			}

		}


		if(((player.position - jumpBox.transform.position).magnitude < 3f) &&
			jumpBox.activeSelf){

			if(!hasBox){

				textBuffer = "Press [SPACE] to pick up an energetic box";

				if(Input.GetKeyDown(KeyCode.Space)){
					hasBox = true;
					boxType = 2;
					player.GetComponent<playerMovement>().hasBox = true;
					player.GetComponent<playerMovement>().boxType = "jump";

					//Dont destroy it, instead just hide it, then make it active and teleport it when you place it
					jumpBox.SetActive(false);
				}
			}

			if(hasBox){
				textBuffer = "You cannot hold more than 1 box";
			}

		}

		//Consider not doing a buffer maybe
		hintHelp.text = textBuffer;
		
	}
}
