using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour {

	public Text hintHelp;
	public Transform player;
	public Transform fastBox;
	public Transform heavyBox;
	//bool hasBox = false;
	//int boxType = 0;

	// Use this for initialization
	void Start () {

		//GameObject player = GameObject.Find("Player");
		//playerMovement playerMovement = player.GetComponent<playerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		string textBuffer = " ";

		if((player.position - fastBox.position).magnitude < 3f){
			textBuffer = "Press [SPACE] to pick up a light box";

			if(Input.GetKeyDown(KeyCode.Space)){
				hasBox = true;
				boxType = 1;
				player.GetComponent<playerMovement>().hasBox = true;
				player.GetComponent<playerMovement>().boxType = "fast";
			}


		}
			
		hintHelp.text = textBuffer;
		
	}
}
