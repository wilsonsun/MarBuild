using UnityEngine;
using System.Collections;

public class visulizationScript : MonoBehaviour {
	public Canvas vCanvas;

	// Use this for initialization
	void Start () {
		vCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Time.timeScale = 0.0f;
			vCanvas.enabled = true;
		}
		
	}

	public void finishedButton () {
		Time.timeScale = 1.0f;
		vCanvas.enabled = false;
		Destroy (gameObject);
	}

}
