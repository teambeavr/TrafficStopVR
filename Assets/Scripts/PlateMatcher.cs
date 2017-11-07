using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateMatcher : MonoBehaviour {

    public GameObject searchScreen;
    public GameObject infoScreen;
    public GameObject searchCanvas;
    public GameObject keyboard;
    public Text plate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Match()
    {
        Debug.Log(plate.text);
        if (plate.text == "abc")
        {
            searchScreen.SetActive(false);
            infoScreen.SetActive(true);
            searchCanvas.SetActive(false);
            keyboard.SetActive(false);
        }
        else
        {
            plate.text = "Wrong Number!";
            Debug.Log("error");
        }
    }
}
