using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

 

public class missiondetect : MonoBehaviour {

	public Image missionImage;


	void Start () {
		missionImage.enabled = false;
	}

	IEnumerator OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Player") {
			if (missionImage) {
				missionImage.enabled = true;    
				yield return new WaitForSeconds (1.0f);
				//missionImage.enabled = false;   
				Destroy (missionImage);
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}

		}
			
	}	

}
