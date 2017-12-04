using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour {
    public Transform target;

    private float rotSpeed = 0f;
    private float zoomSpeed = 20f;
    private bool viewDriver = true;
    private Quaternion rotToDriver;
    private Quaternion rotToVehicle;

    // Use this for initialization
    void Start () {
        rotToDriver = transform.localRotation;
        rotToVehicle = target.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (viewDriver)
        {
            if (transform.rotation != rotToDriver)
            {
                transform.rotation = Quaternion.Lerp(rotToVehicle, rotToDriver, rotSpeed);
                rotSpeed += Time.deltaTime;
            }

            if (transform.GetComponent<Camera>().fieldOfView > 30f)
                transform.GetComponent<Camera>().fieldOfView -= Time.deltaTime * zoomSpeed;
        }
        else
        {
            if (transform.rotation != rotToVehicle)
            {
                transform.rotation = Quaternion.Lerp(rotToDriver, rotToVehicle, rotSpeed);
                rotSpeed += Time.deltaTime;
            }

            if (transform.GetComponent<Camera>().fieldOfView < 90f)
                transform.GetComponent<Camera>().fieldOfView += Time.deltaTime * zoomSpeed;
        }
    }

    public void CallWait() {
        if (viewDriver)
            StartCoroutine(ViewVehicle());
        else
            StartCoroutine(ViewDriver());
    }

    IEnumerator ViewDriver()
    {
        yield return new WaitForSeconds(3);
        rotSpeed = 0;
        viewDriver = !viewDriver;
    }

    IEnumerator ViewVehicle()
    {
        yield return new WaitForSeconds(6);
        rotSpeed = 0;
        viewDriver = !viewDriver;
    }
}
