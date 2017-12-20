using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightOn : MonoBehaviour {

	private String objectTagToUnlock = "Cable";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		GameObject collidedObject = other.gameObject;
		if(collidedObject.tag.Equals(objectTagToUnlock)){
			if(transform.childCount > 0){
				transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
			}
		}	
	}
}
