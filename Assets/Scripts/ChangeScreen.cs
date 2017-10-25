using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour {

    private int index = 0;
    private Material[] m_list;
    private SteamVR_TrackedObject trackedObj;
    private Valve.VR.EVRButtonId grip = Valve.VR.EVRButtonId.k_EButton_Grip;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        m_list = transform.gameObject.GetComponent<MeshRenderer>().materials;
        //StartCoroutine(RunSwitch());
	}
	
	// Update is called once per frame
	void Update () { if (controller.GetPressDown(grip)) { SwtchScreen(); } }

    private void SwtchScreen()
    {
        index = (index + 1) % m_list.Length;
        transform.gameObject.GetComponent<MeshRenderer>().material = m_list[index];
    }

    IEnumerator RunSwitch()
    {
        yield return new WaitForSeconds(5);
        SwtchScreen();
    }
}
