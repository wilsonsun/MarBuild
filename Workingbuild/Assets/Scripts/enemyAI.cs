using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyAI : MonoBehaviour {
	public float speed;
	public Image gameOverimg;
	// Use this for initialization
	void Start () {
		gameOverimg.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "bullet") {
			Destroy (gameObject);

		} else if (other.gameObject.tag == "Player") {
			gameOverimg.enabled = true;
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}

	}

}
