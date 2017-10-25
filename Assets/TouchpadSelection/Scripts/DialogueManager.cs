using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour {
    // Event handlers
    [System.Serializable]
    public class DialogueEvent : UnityEvent<DialogueAct> { }

    [Tooltip("Callbacks -- triggered when the act changes")]
    public DialogueEvent act_ChangedEvents;
    
    public delegate void DialogueEventHandler(DialogueAct act); // Optional code-based events
    public event DialogueEventHandler ActChanged;

    // Response selected event handlers
    [System.Serializable] 
    public class DialogueResponseEvent : UnityEvent<DialogueAct, int> { }

    [Tooltip("Callbacks -- triggered when a response is selected")]
    public DialogueResponseEvent response_SelectedEvents;

    public delegate void DialogueResponseSelectedEventHandler(DialogueAct act, int responseId); // Optional code-based events
    public event DialogueResponseSelectedEventHandler ResponseSelected;

    // Act state
    public DialogueAct startingAct;

    private DialogueAct currentAct;
    public DialogueAct CurrentAct
    {
        set
        {
            currentAct = value;

            // Trigger act events
            currentAct.TriggerEvents();

            // Invoke actChanged events
            act_ChangedEvents.Invoke(currentAct);
            ActChanged(currentAct);
        }
        get { return currentAct; }
    }

    private void OnEnable()
    {
        // Trigger the first act
        CurrentAct = startingAct;
    }

    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update () {
		
	}

    public void TriggerResponse(int responseId)
    {
        // Fire events
        response_SelectedEvents.Invoke(currentAct, responseId);
        ResponseSelected(currentAct, responseId);

        // Change current act to next act based on response
        CurrentAct = currentAct.GetResponseNextAct(responseId);
    }
}
