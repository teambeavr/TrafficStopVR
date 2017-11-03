using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViveInteractionEvents : MonoBehaviour {
    public UnityEvent OnHoverStart;
    public UnityEvent OnHoverEnd;
    public UnityEvent OnGrabStart;
    public UnityEvent OnGrabEnd;
    
    public bool IsHovering
    {
        get;
        private set;
    }

    public bool IsGrabbing
    {
        get;
        private set;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnViveHoverStart(ViveControllerHandler handler)
    {
        IsHovering = true;
        OnHoverStart.Invoke();
    }

    private void OnViveHoverEnd(ViveControllerHandler handler)
    {
        IsHovering = false;
        OnHoverEnd.Invoke();
    }

    private void OnViveGrabStart(ViveControllerHandler handler)
    {
        IsGrabbing = true;
        OnGrabStart.Invoke();
    }

    private void OnViveGrabEnd(ViveControllerHandler handler)
    {
        IsGrabbing = false;
        OnGrabEnd.Invoke();
    }
}
