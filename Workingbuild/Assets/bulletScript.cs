using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bulletScript : MonoBehaviour {
	public Text goalDispText;
	public Image gameOverImg;
	public GameObject shootButton;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemyone") {
			//goalDispText.text = "Congrez!!! You kill your first enemy!";
			yield return new WaitForSeconds (2.0f);
			goalDispText.text = "";

		} else if (other.gameObject.tag == "Player") {
			
			gameOverImg.enabled = true;
			shootButton.SetActive (false);
			//yield WaitForSeconds(3);
			//yield return new WaitForSeconds (3.0f);
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			print ("Loaded scene");
		}
		
	}
}
