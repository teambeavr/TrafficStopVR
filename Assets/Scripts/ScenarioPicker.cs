using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioPicker : MonoBehaviour {
    private int scenario = -1;
	
	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "OutsideScene")
        {
            LoadOutsideDialogue();
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
        GameObject go = null;
        switch (scenario)
        {
            default:
            case 1:
                go = GameObject.Find("[Stop]");
                break;
            case 2:
                go = GameObject.Find("[Turn]");
                break;
            case 3:
                go = GameObject.Find("[Reckless]");
                break;
        }

        if (go != null)
        {
            go.GetComponent<AudioSource>().playOnAwake = true;
        }
    }
}
