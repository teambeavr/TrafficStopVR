using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipVeiw : MonoBehaviour {

    private Camera cam;

    // Use this for initialization
    void Start() { cam = GetComponent<Camera>(); }

    // Update is called once per frame
    void Update () { }

    void OnPreCull()
    {
        cam.ResetWorldToCameraMatrix();
        cam.ResetProjectionMatrix();
        cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }
}