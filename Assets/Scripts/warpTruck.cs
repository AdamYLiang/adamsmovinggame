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
			player.transform.position = ( new Vector3(-20,2,-35));
		}
		

	}

	void OnTriggerExit(Collider activator){

		hints.text = " ";
	}
		
}