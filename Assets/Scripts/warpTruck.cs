using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class warpTruck : MonoBehaviour {

	public GameObject player; 
	public Text hints;
	public bool warped;

	void OnTriggerEnter(Collider activator){
		
		hints.text = "Press [G] to go back to base";
	}

	void OnTriggerStay (Collider activator) {
		//Destroy(activator.gameObject);
		//Time.time is number of seconds elapsed in game;

		if(Input.GetKeyDown(KeyCode.G)){
			player.transform.position = ( new Vector3(-18,2,-14));
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