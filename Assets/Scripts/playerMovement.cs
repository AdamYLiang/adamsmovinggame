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
	public float cameraX;
	public float jumpSpeed = 30f;
	public float custGravity = 20f;
	private Vector3 moveDirection = Vector3.zero;

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
		Vector3 fMovement = transform.forward * speed * vertical;
		myCharController.Move((fMovement + Physics.gravity) * Time.deltaTime);
		Vector3 rMovement = transform.right * speed * horizontal;
		myCharController.Move((rMovement + Physics.gravity) * Time.deltaTime);

		//transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, cameraX, 0f);
		//transform.rotation.y = cameraX;

		//transform.Rotate(0f, horizontal * 90f * Time.deltaTime, 0f);
	

		if(hasBox){

			if(boxType == "fast"){
				textBuffer += "Fast Box";
				speed = 15f;
			}

			if(boxType == "jump"){
				textBuffer += "Jump Box";
				if(Input.GetKeyDown(KeyCode.Space)){
					if(myCharController.isGrounded){
						//Still working on jump
						//This one is the on documentation 
						moveDirection.y = jumpSpeed;
						//Below is the other one 
						//myCharController.Move(new Vector3(0,10,0);
					}
				}
				moveDirection.y -= custGravity * Time.deltaTime;
				myCharController.Move((moveDirection) * Time.deltaTime);
			}

			if(boxType == "heavy"){
				textBuffer += "Heavy Box";
				speed = 2f;
				}

		}

		else{
			speed = 5f;
			textBuffer += "Nothing";
		}

		holdingHelper.text = textBuffer;
	}

	/*
	 * Whats next:
	 * Movement and camera are working
	 * 
	 * Now just work on pick up boxes and placing them
	 * You are making sure that you set the box active and deactivate if picked up
	 * Next is to model and move around
	 * Make it at time attack
	 * */
}
