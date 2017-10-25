using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleDialogueHandler : MonoBehaviour {
    public DialogueManager dialogueMgr;
    public TouchpadSelectionUI selectionUI;

    [Tooltip("(Optional)")]
    public Text promptDisplay;

    [Tooltip("(Optional)")]
    public Text responseDisplay;

    // Use this for initialization
    void Start () {
        // Subscribe to events
        dialogueMgr.ActChanged += DialogueMgr_DialogueActChanged;
        dialogueMgr.ResponseSelected += DialogueMgr_ResponseSelected;
        selectionUI.ChoiceSelected += SelectionUI_ChoiceSelected;
        
        // Activate dialogue manager
        dialogueMgr.enabled = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void DialogueMgr_DialogueActChanged(DialogueAct act)
    {
        if (!act)
        {
            // Clear prompt and touchpad
            if (promptDisplay)
            {
                promptDisplay.text = "";
            }
            selectionUI.SetChoices();
        }

        // Display prompt
        if (promptDisplay)
        {
            promptDisplay.text = act.prompt;
        }

        // Send responses to touchpad UI
        selectionUI.SetChoices(act.response1, act.response2, act.response3, act.response4);
        selectionUI.SetChoicesData(1, 2, 3, 4); // Set response Id
    }
    
    private void DialogueMgr_ResponseSelected(DialogueAct act, int responseId)
    {
        // Echo response
        Debug.Log("Dialog selected: " + act.GetResponse(responseId));
        if (responseDisplay)
        {
            responseDisplay.text = "(" + act.GetResponse(responseId) + ")";
        }
    }

    private void SelectionUI_ChoiceSelected(TouchpadSelectionChoice choice)
    {
        // Switch dialogue act
        dialogueMgr.TriggerResponse((int)choice.Data); // Data stores response Id
    }
}
