using UnityEngine;
using System.Collections;

public class TankRotate : MonoBehaviour {
	public float rotateSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);


	}
}
