using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyMouseButtonInputEvent : MonoBehaviour
{
    public int mouseButton;
    public bool AI;
    public UnityEvent OnButtonDown;
    public UnityEvent OnButton;
    public UnityEvent OnButtonUp;

    void Start()
    {
        
    }

    void Update()
    {
        if (!AI)
        {
            if (Input.GetMouseButtonDown(mouseButton))
            {
                OnButtonDown.Invoke();
            }
            if (Input.GetMouseButton(mouseButton))
            {
                OnButton.Invoke();
            }
            if (Input.GetMouseButtonUp(mouseButton))
            {
                OnButtonUp.Invoke();
            }
        }
    }
    public void OnDown()
    {
        OnButtonDown.Invoke();
    }
    public void OnHold()
    {
        OnButton.Invoke();
    }
    public void OnUp()
    {
        OnButtonUp.Invoke();
    }
}