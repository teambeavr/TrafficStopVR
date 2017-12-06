// Patrol.cs
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections;
public class Dog_Walking : MonoBehaviour
{
    public AudioSource m_Audio;
    private Animator m_Animator;
    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if(m_Animator.GetBool("isBeep") == false)
            agent.speed = 1.0f;
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();      
    }

    public void ClickBeep()
    {
        agent.speed = 0.0f;
        m_Animator.SetBool("isBeep", true);
    }

    void BackToWalk()
    {
        m_Animator.SetBool("isBeep", false);
    }

    void StartBark()
    {
        
        m_Audio.Play();
    }
}