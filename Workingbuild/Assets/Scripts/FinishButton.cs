using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FinishButton : MonoBehaviour {

	public GameObject PlanAText;
	public GameObject PlanBText;
	public GameObject PlanCText;
	public GameObject GoalSetText;
	public Dropdown dropdown;
	public Dropdown dropdown1;
	public Dropdown dropdown2;
	public GameObject FiniButton;
	public GameObject ShowButton;
	public GameObject Map;
	public GameObject tempDropDown;
	public GameObject tempDropDown1;
	public GameObject tempDropDown2;
	public Text Decision;
	public Text Decision1;
	public Text Decision2;

	private GameObject PlanDecision;
	private GameObject PlanDecision1;
	private GameObject PlanDecision2;
	private bool trigger;

	public GameObject watch;

	public delegate void TouchAction();
	public static event TouchAction OnTouch;
	public static event TouchAction OnWatch;


	// Use this for initialization
	void Start () {
		ShowButton.SetActive (false);
		trigger = true;
	}

	// Update is called once per frame
	void Update () {

	}

	public void DisableCanvas() {
		trigger = !trigger;
		PlanAText.SetActive(trigger);
		PlanBText.SetActive(trigger);
		PlanCText.SetActive(trigger);
		FiniButton.SetActive(trigger);

		Debug.Log (dropdown.captionText.text);
		Decision.text = dropdown.captionText.text;
		Decision1.text = dropdown1.captionText.text;
		Decision2.text = dropdown2.captionText.text;
		Decision.enabled = false;
		Decision1.enabled = false;
		Decision2.enabled = false;

		GoalSetText.SetActive (false);
		tempDropDown.SetActive (trigger);
		tempDropDown1.SetActive (trigger);
		tempDropDown2.SetActive (trigger);
		Map.SetActive (trigger);
		ShowButton.SetActive (!trigger);

	}

	public void EnableCanvas() {
		trigger = !trigger;
		Map.SetActive(trigger);
		Decision.enabled = trigger;
		Decision1.enabled = trigger;
		Decision2.enabled = trigger;
		PlanAText.SetActive(trigger);
		PlanBText.SetActive(trigger);
		PlanCText.SetActive(trigger);

	}

	public void fireOnTouch() {

		if (OnTouch != null) {
			Debug.Log ("being fired");
			OnTouch();
		}
	}

	public void fireOnWatch(){
		if (OnWatch != null)
			OnWatch ();
		watch.SetActive (!watch.activeSelf);

	}
	/*
	public void fireoffOnWatch() {
		if (OnWatch != null)
			OnWatch ();
		watchCamera.SetActive (!watchCamera.activeSelf);
	}*/
}
