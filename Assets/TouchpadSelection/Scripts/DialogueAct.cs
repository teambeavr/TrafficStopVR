using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueAct : MonoBehaviour {
    [TextArea(2, 5)]
    public string prompt;

    [Tooltip("Actions to take when this act is triggered")]
    public UnityEvent events;

    // TODO: In the future, have arbitrary # of responses
    [Space()]
    public string response1;
    public DialogueAct response1NextAct;

    [Space()]
    public string response2;
    public DialogueAct response2NextAct;

    [Space()]
    public string response3;
    public DialogueAct response3NextAct;

    [Space()]
    public string response4;
    public DialogueAct response4NextAct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetResponse(int responseId)
    {
        switch (responseId)
        {
            default:
            case 1:
                return response1;
            case 2:
                return response2;
            case 3:
                return response3;
            case 4:
                return response4;
        }
    }

    public DialogueAct GetResponseNextAct(int responseId)
    {
        switch (responseId)
        {
            default:
            case 1:
                return response1NextAct;
            case 2:
                return response2NextAct;
            case 3:
                return response3NextAct;
            case 4:
                return response4NextAct;
        }
    }

    public void TriggerEvents()
    {
        events.Invoke();
    }
}
