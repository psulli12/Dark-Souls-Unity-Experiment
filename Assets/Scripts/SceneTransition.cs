using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{

	private float fadeSpeed = 0.75f;
	private bool sceneStarting = true;
	private bool sceneEnding = false;
	private RawImage FadeImg;

	// Use this for initialization
	void Start ()
	{
		FadeImg = this.GetComponent<RawImage>();
		FadeImg.uvRect = new Rect (0, 0, Screen.width, Screen.height);
		FadeImg.SetNativeSize ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(sceneStarting)
			StartScene();

		else if (sceneEnding)
			EndScene();
	}

	public void SignalEnd()
	{
		sceneEnding = true;
	}

	void StartScene()
	{
		FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
		if(FadeImg.color.a <= 0.05f)
		{
			FadeImg.color = Color.clear;
			FadeImg.enabled = false;
			sceneStarting = false;
		}
	}

	void EndScene()
	{
		FadeImg.enabled = true;
		FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
		if(FadeImg.color.a >= 0.95f)
			Application.LoadLevel(Application.loadedLevel);
	}
}
