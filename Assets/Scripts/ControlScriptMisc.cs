using UnityEngine;
using System.Collections;

public class ControlScriptMisc : MonoBehaviour {

	private GameObject controls;
	private GameObject reminder;

	void Start () {
		controls = GameObject.Find("Controls");
		reminder = GameObject.Find("SoulsReminder");
		reminder.SetActive(false);
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
			Toggle(controls);

		if (GameObject.Find("SoulFire(Clone)") == null)
			reminder.SetActive(false);
	}

	void Toggle(GameObject UIElement)
	{
		if (UIElement.activeInHierarchy == false)
			UIElement.SetActive(true);
		else UIElement.SetActive(false);
	}

	public void ReminderText()
	{
		Toggle(reminder);
	}
}
