using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Instructiondisp : MonoBehaviour {
	public Text instructionText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (gameObject.name == "InstructionWall") {
				instructionText.text = "Tap the middle of the screen to open the door. If you still can't open, that means you trigger the tripwire, you have to get to the terminal on the right and play n-gram inorder to open the door";
			} else {
				instructionText.text = "Tap the middle of the screen to open the door";
			}

			yield return new WaitForSeconds (5.0f);
			instructionText.text = "";
			Destroy (gameObject);
		}
	}
}
