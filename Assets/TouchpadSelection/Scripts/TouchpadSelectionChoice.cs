using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchpadSelectionChoice : MonoBehaviour {
    public enum TouchpadDirection
    {
        Left = 0,
        Up,
        Right,
        Down
    }

    public Text choiceText;
    public Image choiceImage;

    public Color defaultColor = new Color(0, 1, 1);
    public Color selectedColor = new Color(1, 1, 0);

    private TouchpadDirection direction;
    public TouchpadDirection Direction
    {
        set { direction = value; }
        get { return direction; }
    }

    private bool active = true;
    public bool Active
    {
        set
        {
            active = value;

            choiceText.gameObject.SetActive(active);
            choiceImage.gameObject.SetActive(active);

            // Hide or show the choice
            /*
            Color color = choiceImage.color;
            if (active)
            {
                color.a = 1;
            }
            else
            {
                color.a = 0;
            }
            choiceImage.color = color;
            */
        }
        get { return active; }
    }

    public string Text
    {
        set { choiceText.text = value; }
        get { return choiceText.text; }
    }

    private bool selected = false;
    public bool Selected
    {
        set
        {
            selected = active ? value : false; // Force selection to false if not active
            choiceImage.color = selected ? selectedColor : defaultColor;
        }
        get { return selected; }
    }

    private object data; // Arbitrary tag data to associate with choice
    public object Data
    {
        set { data = value; }
        get { return data; }
    }

	// Use this for initialization
	void Awake () {
		if (!choiceText)
        {
            choiceText = GetComponentInChildren<Text>();
        }

        if (!choiceImage)
        {
            choiceImage = GetComponentInChildren<Image>();
        }

        // Set to default color
        Selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
