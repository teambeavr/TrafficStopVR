using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerHandler : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_TrackedController trackedController;

    private GameObject _hoverObject;
    public GameObject HoverObject
    {
        private set
        {
            if (_hoverObject)
            {
                // Notify object of hover end
                _hoverObject.SendMessage("OnViveHoverEnd", this, SendMessageOptions.DontRequireReceiver);
            }

            _hoverObject = value;

            if (_hoverObject)
            {
                // Notify object of hover start
                _hoverObject.SendMessage("OnViveHoverStart", this, SendMessageOptions.DontRequireReceiver);
            }
        }

        get
        {
            return _hoverObject;
        }
    }

    private GameObject _grabObject;
    public GameObject GrabObject
    {
        private set
        {
            if (_grabObject)
            {
                // Notify object of grab end
                _grabObject.SendMessage("OnViveGrabEnd", this, SendMessageOptions.DontRequireReceiver);
            }

            _grabObject = value;

            if (_grabObject)
            {
                // Notify object of grab start
                _grabObject.SendMessage("OnViveGrabStart", this, SendMessageOptions.DontRequireReceiver);
            }
        }

        get
        {
            return _grabObject;
        }
    }

    public bool IsHovering
    {
        get { return HoverObject != null; }
    }

    public bool IsGrabbing
    {
        get { return GrabObject != null; }
    }

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        trackedController = GetComponent<SteamVR_TrackedController>();

        // Controller event handlers
        trackedController.TriggerClicked += TrackedController_TriggerClicked;
        trackedController.TriggerUnclicked += TrackedController_TriggerUnclicked;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    //  Controller events
    //

    private void TrackedController_TriggerClicked(object sender, ClickedEventArgs e)
    {
        if (HoverObject)
        {
            GrabObject = HoverObject;
            HoverObject = null;
        }
    }

    private void TrackedController_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        GrabObject = null;
    }

    //
    //  Collider events
    //

    public void OnTriggerEnter(Collider c)
    {
        if (!HoverObject && !GrabObject)
        {
            HoverObject = c.gameObject;
        }
    }

    public void OnTriggerStay(Collider c)
    {
        OnTriggerEnter(c);
    }

    public void OnTriggerExit(Collider c)
    {
        HoverObject = null;
    }
}
