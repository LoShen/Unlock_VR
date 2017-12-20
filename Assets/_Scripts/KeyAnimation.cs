using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour {

	public void PlayKeyAnimation(){
		GetComponent<Animation>().Play();
	}
}
