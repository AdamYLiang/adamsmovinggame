using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class beginningScriptBox : MonoBehaviour {

	public GameObject player; 
	public Text hints;
	bool beginning = true;
	float timer = 4f;

	void OnTriggerEnter(Collider activator){

		timer = 4f;
		beginning = true;
			
	}

	void OnTriggerStay(Collider activator){
		if(beginning){
			if(timer > 0f){
				hints.text = "Time to drop off all the moving boxes to the new house over there.";
			}
			timer -= Time.deltaTime;
		}

		if(timer < 0.5f){
			beginning = false;
			hints.text = " ";
		}

	}

	void OnTriggerExit(Collider activator){
		if(beginning){
			beginning = false;
			hints.text = " ";
		}
	}
		

}
