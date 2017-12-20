using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTV : MonoBehaviour {

	public List<GameObject> lights;
	private bool isTVOn = false;
	public GameObject TV;
	public Material activeMaterial;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TurnTV();
	}

	public void TurnTV(){
		if(!isTVOn && Attempt()){
			TV.GetComponent<MeshRenderer>().material = activeMaterial;
			isTVOn = true;
			GetComponent<AudioSource>().Play();
		}
	}

	// return true only if lights 1 & 5 are active in hierarchy
	public bool Attempt(){
		return !isActive(lights[0]) && isActive(lights[1]) && !isActive(lights[2]) && !isActive(lights[3]) && !isActive(lights[4]) && isActive(lights[5]);
	}

	// return true if the light is active in hierarchy
	public bool isActive(GameObject light){
		return light.activeInHierarchy;
	}
}
