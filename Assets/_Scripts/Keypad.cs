using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VRTK;
using VRTK.UnityEventHelper;

public class Keypad : MonoBehaviour {
	[SerializeField]
	public String nb;

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


/*	void OnTriggerEnter(Collider other){
		Debug.Log(nb + " added to attempt");
		OpenDoor.attempt += nb;
		GetComponent<AudioSource>().Play();
	}*/

	 private void handlePush(object sender, Control3DEventArgs e)
        {
        	Debug.Log(nb + " added to attempt");
            OpenDoor.attempt += nb;
			GetComponent<AudioSource>().Play();
        }
}