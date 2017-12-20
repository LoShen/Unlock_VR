using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VRTK;
using VRTK.UnityEventHelper;

public class CleanPad : MonoBehaviour {

	private VRTK_Button_UnityEvents buttonEvents;

     private void Start()
        {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

    private void handlePush(object sender, Control3DEventArgs e)
        {
        	Debug.Log("CLEANED ATTEMPT");
		OpenDoor.attempt = "";
		GetComponent<AudioSource>().Play();
        }

	/*void OnTriggerEnter(Collider other){
		Debug.Log("CLEANED ATTEMPT");
		OpenDoor.attempt = "";
		GetComponent<AudioSource>().Play();
	}*/
}
