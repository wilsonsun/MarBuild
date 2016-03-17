using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TankAI : MonoBehaviour {
	public Rigidbody projectile;
	public float speed;
	int interval = 1; 
	float nextTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextTime) {

			Shoot ();

			nextTime += interval; 

		}

	}

	public void Shoot() {
		Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
		//print (instantiatedProjectile);
		instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
		Destroy (instantiatedProjectile.gameObject, 3);
	}
}