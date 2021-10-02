using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyRandomSimpleEvent : MonoBehaviour
{
    public UnityEvent[] Events;

    void Start()
    {
        
    }

    public void PlayRandomEvent()
    {
        int rand = Random.Range(0, Events.Length);
        Events[rand].Invoke();
    }
    public void playSpecificEvent(int value)
    {
        Events[value].Invoke();
    }
}