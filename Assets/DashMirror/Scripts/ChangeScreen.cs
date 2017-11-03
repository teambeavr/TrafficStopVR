using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour {

    private int index = 0;
    private Material[] m_list;
    private SteamVR_TrackedController trackedCtrl;

//    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

	// Use this for initialization
	//void Start () { m_list = GameObject.Find("Mesh671").GetComponent<MeshRenderer>().materials; }

    void Update() { }

    private void OnEnable()
    {
        trackedCtrl = GetComponent<SteamVR_TrackedController>();
        trackedCtrl.TriggerClicked += TriggerHandler;
        m_list = GameObject.Find("Mesh671").GetComponent<MeshRenderer>().materials;
    }

    private void OnDisable() { trackedCtrl.TriggerClicked -= TriggerHandler; }

    private void TriggerHandler(object sender, ClickedEventArgs e) { SwitchScreen(); }

    private void SwitchScreen()
    {
        Debug.Log(m_list.Length);
        Debug.Log(index);
        index = (index + 1) % m_list.Length;
        GameObject.Find("Mesh671").GetComponent<MeshRenderer>().material = m_list[index];
    }
}
