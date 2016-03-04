using UnityEngine;
using System.Collections;

public class SoulFirePersist : MonoBehaviour
{
	private bool retrieving = false;
	private bool inRange = false;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.E) && inRange && !retrieving)
		{
			GameObject.Find("Canvas").GetComponent<ControlScriptMisc>().ReminderText();
			retrieving = true;
			GameObject.Find("DeathAudio").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("youdied"));
			StopFire();
		}

		if (!this.GetComponent<ParticleSystem>().IsAlive())
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player" && !GameObject.Find("FPSController").GetComponent<PlayerHealth>().isDying())
        {
            inRange = true;
            GameObject.Find("Canvas").GetComponent<ControlScriptMisc>().ReminderText();
        }
        
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !GameObject.Find("FPSController").GetComponent<PlayerHealth>().isDying() && !retrieving)
        {
            inRange = false;
            GameObject.Find("Canvas").GetComponent<ControlScriptMisc>().ReminderText();
        }
    }

    public void StopFire()
    {
    	this.GetComponent<ParticleSystem>().Stop();
    }
}