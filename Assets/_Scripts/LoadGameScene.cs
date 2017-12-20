using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log("TRIGGERED");
		SceneManager.LoadScene("Introduction");
	}
}
