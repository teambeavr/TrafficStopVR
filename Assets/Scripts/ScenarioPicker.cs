using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioPicker : MonoBehaviour {
    private int scenario = -1;
	
	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        // Check if in initial scene or not
        if (GameObject.FindObjectOfType<DialogueManager>() == null)
        {
            LoadOutsideDialogue();
        }
        else
        {
            LoadScenarioDialogue();
        }
    }

    public void SetScenario(int scenario)
    {
        this.scenario = scenario;
    }

    public void LoadScenarioDialogue()
    {
        var dlg = GameObject.FindObjectOfType<DialogueManager>();
        switch (scenario)
        {
            default:
            case 1:
                dlg.startingAct = GameObject.Find("[Stop]").GetComponent<DialogueAct>();
                break;
            case 2:
                dlg.startingAct = GameObject.Find("[Turn]").GetComponent<DialogueAct>();
                break;
            case 3:
                dlg.startingAct = GameObject.Find("[Reckless]").GetComponent<DialogueAct>();
                break;
        }
    }

    public void LoadOutsideDialogue()
    {

    }
}
