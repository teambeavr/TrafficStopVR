using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoOnEnable : MonoBehaviour {
    public float delayTime = 0;
    public UnityEvent onEnable;

    void OnEnable()
    {
        StartCoroutine(DoAfterTime());
    }

    IEnumerator DoAfterTime()
    {
        yield return new WaitForSeconds(delayTime);
        onEnable.Invoke();
    }
}
