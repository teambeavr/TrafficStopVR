using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextInteractionHint : MonoBehaviour {
    [Tooltip("If set to true, will set the next hint as soon as the component is enabled.")]
    public bool setOnEnable = false;

    [Tooltip("If set to true, will only set the next hint the first time the component is enabled.")]
    public bool displayOnce = false;

    [Tooltip("Array of objects to activate as the next interactable items.")]
    public GameObject[] nextInteractions;

    [Tooltip("Fired when EnableHints() is called.")]
    public UnityEvent onHintsEnabled;

    private InteractionHintSystem hintSystem;
    private bool firstTime = true;

	// Use this for initialization
	void Awake () {
        // Get hint system
        hintSystem = FindObjectOfType<InteractionHintSystem>();

        if (hintSystem == null)
        {
            Debug.LogError("InteractionHintSystem NOT FOUND!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        if (setOnEnable && firstTime)
        {
            EnableHints();
            firstTime = false;
        }
    }

    public void EnableHints()
    {
        hintSystem.SetNextInteractions(nextInteractions);
    }
}
