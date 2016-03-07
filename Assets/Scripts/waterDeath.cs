using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class waterDeath : MonoBehaviour {

	public GameObject player; 

	void OnTriggerEnter(Collider activator){

		SceneManager.LoadScene(2);

	}
}
