using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour {
	public Text goalDispText;
	public Image gameOverImg;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemyone") {
			goalDispText.text = "Congrez!!! You kill your first enemy!";
			yield return new WaitForSeconds (2.0f);
			goalDispText.text = "";

		} else if (other.gameObject.tag == "Player") {
			gameOverImg.enabled = true;
		}
		
	}
}
