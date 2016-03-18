using UnityEngine;
using System.Collections;

public class tbTUT : MonoBehaviour {
	private float speed = 0;
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject tbPopup;
	private int mv = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		enemy.transform.Translate(Vector3.forward * speed*Time.deltaTime);
		enemy2.transform.Translate(Vector3.forward * speed*Time.deltaTime);
		enemy3.transform.Translate(Vector3.forward * speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			speed = 0.2f;
			tbPopup.SetActive (true);
			mv = 1;
		}
	}

	public void disableTB() {
		if (mv == 1) {
			tbPopup.SetActive (false);
			Destroy (gameObject);
		}
	}
}
