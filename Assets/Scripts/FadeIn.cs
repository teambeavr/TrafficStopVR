using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    public bool visible = false;
    public float fadeTime = 1f; // Number of seconds to fade out
    private float curLerp = 0;

    private Image image;
    private Color color;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        color = image.color;
        curLerp = visible ? 1 : 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!visible)
        {
            curLerp -= Time.deltaTime / fadeTime;
            if (curLerp < 0) curLerp = 0;
        }
        else
        {
            curLerp += Time.deltaTime / fadeTime;
            if (curLerp > 1) curLerp = 1;
        }

        image.color = new Color(color.r, color.g, color.b, Mathf.Lerp(0, color.a, curLerp));
	}

    public void DoFadeOut()
    {
        visible = false;
    }

    public void DoFadeIn()
    {
        visible = true;
    }
}
