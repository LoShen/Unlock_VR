using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

public class UnlockChest : MonoBehaviour {
	// Tag of the object that unlock the chest
	private String objectTagToUnlock = "Key";

	void Start () {
		
	}

	IEnumerator OnTriggerEnter(Collider other){
		//Debug.Log(other.gameObject.name);
		//Debug.Log(other.gameObject.tag + " is equals to " + objectTagToUnlock + " : " + other.gameObject.tag.Equals(objectTagToUnlock));
		GameObject collidedObject = other.gameObject;
		if(collidedObject.tag.Equals(objectTagToUnlock)){
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // unlock chest

 			collidedObject.transform.position = new Vector3(4.375f, 0.723f, -1.546f); // Bonjour, je suis sale
 			collidedObject.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
			collidedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			collidedObject.GetComponentInChildren<Animator>().SetTrigger("Chest");
			collidedObject.GetComponentInChildren<AudioSource>().Play();
			yield return new WaitForSeconds(collidedObject.GetComponentInChildren<AudioSource>().clip.length);

			Destroy(collidedObject);
			// lancer l'ouverture du coffre
			// éventuellement une petite musique fort sympathique
		}
	}
}
