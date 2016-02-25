using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	CharacterController myCharController;

	// Use this for initialization
	void Start () {

		myCharController = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 movement = transform.forward * 5f * vertical;

		myCharController.Move((movement + Physics.gravity) * Time.deltaTime);
		transform.Rotate(0f, horizontal * 90f * Time.deltaTime, 0f);
	}
}
