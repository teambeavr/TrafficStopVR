using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionHintSystem : MonoBehaviour {
    [Tooltip("Time (in seconds) to wait before displaying next hint.")]
    public float waitTimeBeforeHint = 30;
    public Color highlightColor = Color.cyan;
    public float outlineWidth = 0.01f;
    public List<GameObject> nextInteractions;

    public UnityEvent onHintShown;
    public UnityEvent onHintHidden;

    public bool IsHintActive { get; private set; }

    private float elapsedTime = 0;
    private List<HighlightObject> highlightObjects = new List<HighlightObject>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsHintActive)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > waitTimeBeforeHint)
            {
                ShowHint();
            }
        }
    }

    public void SetNextInteraction(GameObject obj)
    {
        SetNextInteractions(new GameObject[] { obj });
    }

    public void SetNextInteractions(GameObject[] objects)
    {
        ResetHint();

        // Update next interaction objects
        nextInteractions.Clear();
        nextInteractions.AddRange(objects);

        UpdateHighlights();
    }

    private void UpdateHighlights()
    {
        highlightObjects.Clear();

        // Add highlight to each object and cache reference
        foreach (GameObject obj in nextInteractions)
        {
            HighlightObject highlight = obj.AddComponent<HighlightObject>();
            highlight.SetColor(highlightColor);
            highlight.SetOutlineWidth(outlineWidth);
            highlightObjects.Add(highlight);
        }
    }

    public void ShowHint()
    {
        if (IsHintActive) return;

        // Highlight all interaction objects
        foreach (HighlightObject highlight in highlightObjects)
        {
            highlight.SetHighlight(true);
        }

        IsHintActive = true;
        onHintShown.Invoke();
    }

    public void ResetHint()
    {
        elapsedTime = 0;
        if (!IsHintActive) return;

        // Un-highlight all interaction objects
        foreach (HighlightObject highlight in highlightObjects)
        {
            highlight.SetHighlight(false);
        }

        IsHintActive = false;
        onHintHidden.Invoke();
    }
}
