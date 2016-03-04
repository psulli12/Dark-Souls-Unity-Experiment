using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	private AudioSource playerAudio;
	bool dying = false;

	// Use this for initialization
	void Start ()
	{
		playerAudio = GameObject.Find("DeathAudio").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q) && !dying)
			Die();
	}

	void Die()
	{
		playerAudio.PlayOneShot((AudioClip)Resources.Load("youdied"));
		dying = true;
		Debug.Log("You died.");
		if (GameObject.Find("SoulFire(Clone)") != null)
			GameObject.Find("SoulFire(Clone)").GetComponent<SoulFirePersist>().StopFire();
		DropFire();
	}

	void DropFire()
	{
     	Instantiate ((GameObject)Resources.Load("SoulFire"), this.transform.position, Quaternion.identity);
     	GameObject.Find("Canvas").GetComponent<SceneTransition>().SignalEnd();
	}

	public bool isDying()
	{
		return dying;
	}
}