using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NBackCoord {
	public int x;
	public int y;

	public NBackCoord()
	{
		x = 0;
		y = 0;
	}

	public NBackCoord(int x_, int y_){
		x = x_;
		y = y_;
	}
}

public class NBackAlgo : MonoBehaviour {

	public delegate void Alert();
	public static event Alert NBackFinished;


	public Transform square;
	public int NLevel = 1;

	//adjust so that the square appears within the centre of each slot
	public float height = 3.5f;
	public float width  = 3.5f;

	public float rateOfChange = 1f;
	public float offsetDist = 0.01f;
	public int correctLength = 1;
	public int maxRunningTurns = 10;

	[Range(30,70)]
	public int skewChance = 30;



	Transform squareClone;
	float timePassed = 0f;
	List<NBackCoord> NBackCoords = new List<NBackCoord>();

	bool squareRepeated = false;
	int timesCorrect = 0;
	int turnsPassed = 0;
	int randInt = 0;
	int origSkewChance;

	// Use this for initialization
	void Start () {
		squareClone = (Transform) Instantiate(square, transform.position + transform.up*offsetDist, Quaternion.Euler(new Vector3(0f, 0f,0f)));
		squareClone.SetParent (this.transform);
		squareClone.transform.localRotation = Quaternion.Euler (new Vector3 (90f, 180f, 180f));

		NBackCoords.Add (new NBackCoord (0, 0));

		squareClone.gameObject.SetActive (false);
		StartCoroutine(CheckingForRepeatSquare());
		origSkewChance = skewChance;
	}

	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;

		if (timePassed > 0 && timePassed < rateOfChange * 0.5)
			squareClone.gameObject.SetActive (true);
		else
			squareClone.gameObject.SetActive (false);

		if (timePassed > rateOfChange){
			int x, y;
			squareClone.gameObject.SetActive (false);

			randInt = Random.Range (0, 101);

			x = Random.Range (-1, 2);
			y = Random.Range (-1, 2);

			//skew square positioning!
			if (randInt < skewChance && NBackCoords.Count > NLevel) {
				print ("Skewing position");
				print ("randInt: " + randInt + " skewChance: " + skewChance);

				x = NBackCoords [NLevel-1].x;
				y = NBackCoords [NLevel-1].y;

				skewChance = origSkewChance;
			} else if (NBackCoords.Count > NLevel){
				skewChance += 10;
			}

			PlaceSquare (x, y);

			timePassed = 0f;
		}

		if (timesCorrect >= correctLength) {
			print ("correct enough times");
			NBackPassed ();
		}

		if (turnsPassed > maxRunningTurns) {
			print ("too many turns passed");
			NBackPassed ();
		}

	}

	private void NBackPassed(){
		if(NBackFinished != null)
			NBackFinished();
		NBackCoords.Clear();
		timesCorrect = 0;
		turnsPassed = 0;
		transform.parent.gameObject.SetActive (false);
	}

	private void PlaceSquare(int x, int y){
		//moving square in LOCAL COORDINATES
		squareClone.transform.localPosition = new Vector3 (x*width, offsetDist, y*height);

		//modifying the n back coordinates
		NBackCoord newCoord = new NBackCoord (x, y);

		//checking if list is full
		//if it is, must remove last element of the list
		if (NBackCoords.Count == NLevel + 1) {

			NBackCoords.RemoveAt (NLevel);
		}

		NBackCoords.Insert (0, newCoord);

		turnsPassed++;
		/*print ("-------------------------------------------");
		for(int i =0; i< NBackCoords.Count; i++){
			print (NBackCoords[i].x+", "+NBackCoords[i].y);
		}*/

	}

	void OnEnable(){
		timesCorrect = 0;
		turnsPassed = 0;
		squareRepeated = false;
		StartCoroutine (CheckingForRepeatSquare());
		FinishButton.OnTouch += Signal;
		EventManager.OnTouch += Signal;
	}

	void OnDisable(){
		FinishButton.OnTouch -= Signal;
		EventManager.OnTouch -= Signal;
	}

	void Signal(){
		if (squareRepeated == true) {
			print ("CORRECT!");
			timesCorrect++;
		}
		else
			print ("WRONG");
	}

	IEnumerator CheckingForRepeatSquare() {
		print ("Started listening for input");

		while (true) {

			//check to ensure the enough square havve appeared to 
			//for N level repetitions to actually occur
			while (NBackCoords.Count == NLevel + 1) {

				if (NBackCoords [0].x == NBackCoords [NLevel].x
					&& NBackCoords [0].y == NBackCoords [NLevel].y) {
					print ("Same N back level detected");

					squareRepeated = true;
				}

				else
					squareRepeated = false;
				yield return new WaitForSeconds(rateOfChange);
			}
			yield return new WaitForSeconds(rateOfChange);
		}

		yield return null;
	}

}