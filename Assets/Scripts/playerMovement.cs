using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

	CharacterController myCharController;
	public Text holdingHelper;

	//Instead of having multiple booleans, have one that if true it equates the type of box
	//So boxes 1, 2, 3, 4 instead of 4 booleans. 
	public bool hasBox = false;
	public string boxType = "none";
	public float speed = 5f;

	// Use this for initialization
	void Start () {

		myCharController = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		string textBuffer = "Holding: \n";

		//General Movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 movement = transform.forward * speed * vertical;
		myCharController.Move((movement + Physics.gravity) * Time.deltaTime);
		transform.Rotate(0f, horizontal * 90f * Time.deltaTime, 0f);

		if(hasBox){

			if(boxType == "fast"){
				textBuffer += "Fast Box";
				speed = 15f;
			}
			
		}

		else{
			textBuffer += "Nothing";
		}

		holdingHelper.text = textBuffer;
	}
}
