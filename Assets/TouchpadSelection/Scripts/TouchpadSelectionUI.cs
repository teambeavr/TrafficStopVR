using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchpadSelectionUI : MonoBehaviour {
    // Child selection UI components (consisting of Text and an Image)
    public TouchpadSelectionChoice left;
    public TouchpadSelectionChoice up;
    public TouchpadSelectionChoice right;
    public TouchpadSelectionChoice down;

    // Event handlers
    [System.Serializable]
    public class TouchpadSelectionEvent : UnityEvent<TouchpadSelectionChoice> { }
    
    [Tooltip("Callbacks -- triggered when a selection is made")]
    public TouchpadSelectionEvent choice_SelectedEvents;

    public delegate void TouchpadSelectionEventHandler(TouchpadSelectionChoice choice); // Optional code-based events
    public event TouchpadSelectionEventHandler ChoiceSelected;

    //public GameObject viveController;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_TrackedController trackedController;

    // Touchpad state
    private bool isTouching = false;
    private TouchpadSelectionChoice prevChoice;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Awake() {
        // Get Vive controller
        trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
        trackedController = GetComponentInParent<SteamVR_TrackedController>();

        // Subscribe to touchpad events
        trackedController.PadTouched += TrackedController_PadTouched;
        trackedController.PadUntouched += TrackedController_PadUntouched;
        trackedController.PadClicked += TrackedController_PadClicked;

        // Init choice directions
        left.Direction = TouchpadSelectionChoice.TouchpadDirection.Left;
        up.Direction = TouchpadSelectionChoice.TouchpadDirection.Up;
        right.Direction = TouchpadSelectionChoice.TouchpadDirection.Right;
        down.Direction = TouchpadSelectionChoice.TouchpadDirection.Down;
	}

    private void TrackedController_PadClicked(object sender, ClickedEventArgs e)
    {
        TouchpadSelectionChoice choice = GetSelectedChoice();
        if (choice && choice.Active)
        {
            // Fire events
            choice_SelectedEvents.Invoke(choice);
            ChoiceSelected(choice);
        }
    }

    private void TrackedController_PadTouched(object sender, ClickedEventArgs e)
    {
        prevChoice = null;
        isTouching = true;
    }

    private void TrackedController_PadUntouched(object sender, ClickedEventArgs e)
    {
        SetAllSelected(false);
        isTouching = false;
    }

    private void SetAllSelected(bool selected)
    {
        left.Selected = selected;
        up.Selected = selected;
        right.Selected = selected;
        down.Selected = selected;
    }

    private TouchpadSelectionChoice GetSelectedChoice()
    {
        // Get touchpad coordinates
        Vector2 touchpad = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

        // Convert to angle
        float angle = Mathf.Atan2(touchpad.y, touchpad.x) * Mathf.Rad2Deg;
        angle += 45; // Rotate by 45 degrees CCW to make 0-90 considered the "right" side of the pad -- makes checking easier
        if (angle < 0) angle += 360; // Normalize from 0 to 360
        
        // Check angles and return directions
        if (angle < 90)
        {
            return right;
        }
        else if (angle < 180)
        {
            return up;
        }
        else if (angle < 270)
        {
            return left;
        }
        else
        {
            return down;
        }
    }

    // Update is called once per frame
    void Update () {
		if (isTouching)
        {
            TouchpadSelectionChoice choice = GetSelectedChoice();
            if (choice != prevChoice) // Has the choice changed?
            {
                // Clear choices and re-select
                SetAllSelected(false);
                choice.Selected = true;
                prevChoice = choice;
            }
        }
	}

    public void SetChoices(string choiceLeft = null, string choiceUp = null, string choiceRight = null, string choiceDown = null)
    {
        left.Text = choiceLeft;
        left.Active = !string.IsNullOrEmpty(choiceLeft);

        up.Text = choiceUp;
        up.Active = !string.IsNullOrEmpty(choiceUp);

        right.Text = choiceRight;
        right.Active = !string.IsNullOrEmpty(choiceRight);

        down.Text = choiceDown;
        down.Active = !string.IsNullOrEmpty(choiceDown);
    }

    public void SetChoicesData(object dataLeft = null, object dataUp = null, object dataRight = null, object dataDown = null)
    {
        left.Data = dataLeft;
        up.Data = dataUp;
        right.Data = dataRight;
        down.Data = dataDown;
    }
}
