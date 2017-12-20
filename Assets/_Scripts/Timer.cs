using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour {

	public static int min;
	public static int sec;
	public static float timer = 900.0f;
	private float timecount;
	private float starttime;
	private TextMesh display;
	private AudioSource cloche;
	private String dispNeg;

	// Use this for initialization
	void Start () {
		starttime = 0.0f;
		display = GetComponent<TextMesh>();
		cloche = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		starttime += Time.deltaTime;
		timecount = timer - starttime;
		min = (int)(timecount/60f);
    	sec = (int)(timecount % 60f);
    	int tempM = min;
    	int tempS = sec;
    	if(sec == 0){cloche.Play();}
    	if(min < 0){tempM = - tempM; dispNeg = "-";}
    	else if(sec < 0){tempS = - tempS; dispNeg = "-";}
    	else{dispNeg = "";}
    	display.text = String.Format(dispNeg + "{0:00}:{1:00}", tempM, tempS);
	}
}