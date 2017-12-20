using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;
using VRTK.UnityEventHelper;

public class OpenDoor : MonoBehaviour {

	public static String attempt = "";
	public static String code = "9372"; //9372
	public GameObject congratz;


	[SerializeField]
	public AudioClip goodSound;
	[SerializeField]
	public AudioClip badSound;

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
        	AudioSource audio = GetComponent<AudioSource>();
		if(attempt == code){
			int min = Timer.min;
			int sec = Timer.sec;
			GetComponent<AudioSource>().clip = goodSound;
			GetComponent<AudioSource>().Play();
			float temp = Timer.timer - (min * 60 + sec); 
			min = (int)(temp/60f);
    		sec = (int)(temp % 60f);
			congratz.GetComponentInChildren<Text>().text = String.Format("Félicitations ! \nVotre temps : {0:00}:{1:00}", min, sec);
    		congratz.SetActive(true);
			StartCoroutine(EndGame());
		}
		else {
			GetComponent<AudioSource>().clip = badSound;
			GetComponent<AudioSource>().Play();
			attempt = "";
			Debug.Log("TRY AGAIN");
		}
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds((GetComponent<AudioSource>().clip.length));
			// unlock door
			SceneManager.UnloadSceneAsync("Introduction");
			SceneManager.LoadScene("Presentation");
	}

	/*IEnumerator OnTriggerEnter(Collider other){
		AudioSource audio = GetComponent<AudioSource>();
		if(attempt == code){
			int min = Timer.min;
			int sec = Timer.sec;
			GetComponent<AudioSource>().clip = goodSound;
			GetComponent<AudioSource>().Play();
			float temp = Timer.timer - (min * 60 + sec); 
			min = (int)(temp/60f);
    		sec = (int)(temp % 60f);
			congratz.GetComponentInChildren<Text>().text = String.Format("Félicitations ! \nVotre temps : {0:00}:{1:00}", min, sec);
    		congratz.SetActive(true);
			yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
			// unlock door
			SceneManager.UnloadSceneAsync("Introduction");
			SceneManager.LoadScene("Presentation");
		}
		else {
			GetComponent<AudioSource>().clip = badSound;
			GetComponent<AudioSource>().Play();
			attempt = "";
			Debug.Log("TRY AGAIN");
		}
	}*/
}
