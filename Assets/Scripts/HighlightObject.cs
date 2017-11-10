using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour {
    public Color highlightColor = Color.yellow;
    public float outlineWidth = 0.01f;

    private Material highlightMaterial;
    private Renderer render;

    private GameObject highlightChild;

    public bool IsHighlighted { get; private set; }

	// Use this for initialization
	void Awake () {
        // Create new material for highlight
        //highlightMaterial = new Material(Shader.Find("Custom/InteractionHighlight"));
        highlightMaterial = new Material(Shader.Find("Valve/VR/Silhouette"));

        highlightMaterial.SetColor("g_vOutlineColor", highlightColor);
        highlightMaterial.SetFloat("g_flOutlineWidth", outlineWidth);
        highlightMaterial.SetFloat("g_flCornerAdjust", 0.2f);
        //highlightMaterial.SetFloat("g_bEnableOutline", 0);

        // Duplicate object
        highlightChild = new GameObject("highlight", typeof(MeshFilter), typeof(MeshRenderer));
        highlightChild.GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;

        // Set parent to current object
        highlightChild.transform.parent = transform;
        highlightChild.transform.localPosition = new Vector3();
        highlightChild.transform.localRotation = new Quaternion();
        highlightChild.transform.localScale = new Vector3(1, 1, 1);

        // Set highlight material
        render = highlightChild.GetComponent<Renderer>();
        render.material = highlightMaterial;

        // Hide the object
        highlightChild.SetActive(false);

        // Add material to renderer
        //render = highlightOutline.GetComponent<Renderer>();
        //if (render)
        //{
        //    Get list of materials to modify
        //    List<Material> materials = new List<Material>(render.materials);
        //    materials.Add(highlightMaterial);
        //    render.materials = materials.ToArray();
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(Color color)
    {
        highlightColor = color;
        highlightMaterial.SetColor("g_vOutlineColor", highlightColor);
    }

    public void SetOutlineWidth(float width)
    {
        outlineWidth = width;
        highlightMaterial.SetFloat("g_flOutlineWidth", outlineWidth);
    }

    public void SetHighlight(bool active)
    {
        IsHighlighted = active;
        //highlightMaterial.SetFloat("g_bEnableOutline", IsHighlighted ? 1 : 0);
        highlightChild.SetActive(active);
    }
}
