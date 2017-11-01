using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasColor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Image img = GameObject.Find("Canvas").GetComponent<Image>();
        img.color = UnityEngine.Color.red;
    }

}