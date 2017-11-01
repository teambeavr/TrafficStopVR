using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsInput : MonoBehaviour {

    // 1
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Update is called once per frame
    void Update () {
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log("controller input");
            Input.GetMouseButtonDown(0);
        }
    }
}
