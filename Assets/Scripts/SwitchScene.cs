using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {
    public bool fadeInOnLoad;
    public bool fadeOutOnExit;
    public Color fadeColor = Color.black;
    public float fadeDuration = 2;

	// Use this for initialization
	void Start () {
		if (fadeInOnLoad)
        {
            FadeIn();
        }
	}
	
    public void FadeOut()
    {
        SteamVR_Fade.Start(Color.clear, 0); // Start off clear
        SteamVR_Fade.Start(fadeColor, fadeDuration);
    }

    public void FadeIn()
    {
        SteamVR_Fade.Start(fadeColor, 0); // Start off with color
        SteamVR_Fade.Start(Color.clear, fadeDuration);
    }

    IEnumerator DelayForTime(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

	public void NextScene()
    {
        if (fadeOutOnExit)
        {
            // Start fade out then load scene after time has passed
            FadeOut();
            StartCoroutine(DelayForTime(fadeDuration, delegate
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }));
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }

    public void LoadScene(string sceneName)
    {
        if (fadeOutOnExit)
        {
            // Start fade out then load scene after time has passed
            FadeOut();
            StartCoroutine(DelayForTime(fadeDuration, delegate
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }));
        }
        else
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    public void EndApplication()
    {
        if (fadeOutOnExit)
        {
            // Start fade out then load scene after time has passed
            FadeOut();
            StartCoroutine(DelayForTime(fadeDuration, delegate
            {
                Application.Quit();
            }));
        }
        else
        {
            Application.Quit();
        }
    }
}
