using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMirror : MonoBehaviour {

    public Transform MirrorCam;
    public Transform PlayerCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CalcRotation();
	}

    public void CalcRotation()
    {
        Vector3 dir = (PlayerCam.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;

        MirrorCam.localRotation = rot;
    }
}
