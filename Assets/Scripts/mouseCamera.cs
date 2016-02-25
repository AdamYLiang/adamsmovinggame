using UnityEngine;
using System.Collections;

public class mouseCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public Transform player;
	float rotationY;
	float rotationX;

	// Update is called once per frame
	void Update () {
	
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		/*transform.Rotate(0f, 
			mouseX * Time.deltaTime * 90f, 
			0f);*/

		rotationX += mouseX * Time.deltaTime * 90f;
		//rotationX = Mathf.Clamp(rotationX, -20f, 20f);
		player.localEulerAngles = new Vector3(player.localEulerAngles.x, rotationX, 0f);
		//player.GetComponent<playerMovement>().cameraX = transform.rotation.y;

		rotationY += mouseY * Time.deltaTime * -90f;
		rotationY = Mathf.Clamp(rotationY, -40f, 40f);
		transform.localEulerAngles = new Vector3(rotationY, transform.localEulerAngles.y, 0f);

		//Lock the cursor and put it in the middle
		if(Input.GetMouseButtonDown(0)){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		//Escape to get out of play mode, DELETE THIS LATERRR
		if(Input.GetKeyDown(KeyCode.Escape)){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

	}
	}
}
