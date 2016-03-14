using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class warpTruck : MonoBehaviour {

	public GameObject player; 
	public Text hints;
	public bool warped;

	void OnTriggerEnter(Collider activator){
		
		hints.text = "Your dad offers to drive \n you back to the old house.\n Press [G] to go back to the old house";
	}

	void OnTriggerStay (Collider activator) {
		//Destroy(activator.gameObject);
		//Time.time is number of seconds elapsed in game;

		if(Input.GetKeyDown(KeyCode.G)){
			player.transform.position = ( new Vector3(-21,2,-18));
			//Rotating view isnt working, figure it out 
			//Use fast to go through a garden maze
			//Use jump to jump into traffic and run 
			player.transform.localEulerAngles = new Vector3(0,200,0);
		}
		

	}

	void OnTriggerExit(Collider activator){

		hints.text = " ";
	}
		
}