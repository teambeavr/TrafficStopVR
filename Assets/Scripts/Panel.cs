using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

    public GameObject MessagePanel;
    public Text button;
    int counter;

	// Use this for initialization
	void Start () {
        Image img = GameObject.Find("Panel").GetComponent<Image>();
       // img.color = UnityEngine.Color.cyan;
	}

    public void showHidePanel()
    {
        counter++;
        if (counter%2 == 1)
        {
            MessagePanel.gameObject.SetActive(false);
            button.text = "show hint";
        }
        else
        {
            MessagePanel.gameObject.SetActive(true);
            button.text = "hide hint";
        }
    }
	
}
