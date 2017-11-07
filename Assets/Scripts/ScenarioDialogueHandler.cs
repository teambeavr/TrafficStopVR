using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioDialogueHandler : MonoBehaviour {
    public DialogueManager dialogueMgr;
    public TouchpadSelectionUI selectionUI;


	// Use this for initialization
	void Start () {
        StopDialogue();

        // Subscribe to events
        dialogueMgr.ActChanged += DialogueMgr_DialogueActChanged;
        dialogueMgr.ResponseSelected += DialogueMgr_ResponseSelected;
        selectionUI.ChoiceSelected += SelectionUI_ChoiceSelected;

        //StartDialogue(); // TODO
    }

    private void DialogueMgr_DialogueActChanged(DialogueAct act)
    {
        // Display responses on touchpad UI
        selectionUI.SetChoices(act.response1, act.response2, act.response3, act.response4);
        selectionUI.SetChoicesData(1, 2, 3, 4);
    }
    
    private void DialogueMgr_ResponseSelected(DialogueAct act, int responseId)
    {

    }

    private void SelectionUI_ChoiceSelected(TouchpadSelectionChoice choice)
    {
        if (!selectionUI.gameObject.activeSelf) return; // Ignore if disabled

        SetUIEnabled(false);

        // Switch dialogue act
        dialogueMgr.TriggerResponse((int)choice.Data); // Data stores response Id
    }

    // Update is called once per frame
    void Update () {
        if (!dialogueMgr.enabled)
        {
            return;
        }

        // Check if dialogue audio is playing
        AudioSource audio = dialogueMgr.CurrentAct.GetComponent<AudioSource>();
        if (audio != null)
        {
            // Disable control if audio is playing
            SetUIEnabled(!audio.isPlaying);
        }
	}

    public void SetUIEnabled(bool enabled)
    {
        selectionUI.gameObject.SetActive(enabled);
    }

    public void StartDialogue()
    {
        dialogueMgr.enabled = true;
        SetUIEnabled(true);
    }

    public void StopDialogue()
    {
        dialogueMgr.enabled = false;
        SetUIEnabled(false);
    }
}
