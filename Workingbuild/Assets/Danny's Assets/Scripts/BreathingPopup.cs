using UnityEngine;
using System.Collections;

public class BreathingPopup : MonoBehaviour {
	public Transform secondHand;

	public Vector3 secondHandRot = new Vector3 (0f, 180f, 180f);
	public Vector3 secondHandRotRate = new Vector3 (0f, 6f, 0f);
    public int BREATH_INTERVAL = 1000;

    public int skipChance = 30;
	public int correctLength = 1;

	int timesCorrect = 0;

	Transform secondHandClone;
	float timePassed = 0f;
    
    int intervalPassed = 0;
    bool inhale = true;
	int rand = 0;
    float mag = 0;

	bool timeSkip = false;

	// Use this for initialization
	void Start () {
        mag = 1f+ (3f / (float)BREATH_INTERVAL);
		secondHandClone = (Transform) Instantiate(secondHand, transform.position, Quaternion.Euler(new Vector3(0f, 0f,0f)));
		secondHandClone.transform.SetParent (this.transform);
		secondHandClone.transform.localPosition.Set (0f, 0f, 0f);
		secondHandClone.transform.localRotation = Quaternion.Euler (secondHandRot.x, secondHandRot.y, secondHandRot.z);
	}

	// Update is called once per frame
	void Update () {

		timePassed += Time.deltaTime;

		if (timePassed > 0.01f) {
			inflateCircle();
			timePassed = 0f;
            Debug.Log(intervalPassed);
            intervalPassed++;
		}
        if (intervalPassed == BREATH_INTERVAL) {
            intervalPassed = 0;
            Debug.Log(inhale);
            inhale = !inhale;
        }

		if (timesCorrect >= correctLength) {
			timesCorrect = 0;
			gameObject.transform.parent.gameObject.SetActive(false);
		}
	}

	void OnEnable(){
		//timesCorrect = 0;
		FinishButton.OnTouch += Signal;
	}

	void OnDisable(){
		FinishButton.OnTouch -= Signal;
	}

	void Signal(){
		if (timeSkip == true) {
			print ("CORRECT!!");
			timesCorrect++;
			timeSkip = false;
		} else {
			print ("WRONG!!");
		}
			
	}

	void inflateCircle(){
        if (inhale)
        {
            secondHandClone.transform.localScale = secondHandClone.transform.localScale * mag;
        }
        else {
            secondHandClone.transform.localScale = secondHandClone.transform.localScale / mag;
        }
	}
}
