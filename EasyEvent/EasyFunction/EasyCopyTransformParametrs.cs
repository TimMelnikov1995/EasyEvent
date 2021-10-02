using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventCallMethod1 // создаем выбор метода при помощи которого будем вызывать событие
{
    OnStart,
    OnUpdate,
    OnLateUpdate
}
public class EasyCopyTransformParametrs : MonoBehaviour
{
    public Transform target;
    public EventCallMethod1 eventCallMethod;
    public bool position;
    public bool rotation;
    public bool scale;

    void Start()
    {
        if(eventCallMethod == EventCallMethod1.OnStart)
        {
            if (position)
            {
                transform.position = target.position;
            }
            if (rotation)
            {
                transform.rotation = target.rotation;
            }
            if (scale)
            {
                transform.localScale = target.localScale;
            }
        }
    }

    void Update()
    {
        if (eventCallMethod == EventCallMethod1.OnUpdate)
        {
            if (position)
            {
                transform.position = target.position;
            }
            if (rotation)
            {
                transform.rotation = target.rotation;
            }
            if (scale)
            {
                transform.localScale = target.localScale;
            }
        }
    }

    private void LateUpdate()
    {
        if (eventCallMethod == EventCallMethod1.OnLateUpdate)
        {
            if (position)
            {
                transform.position = target.position;
            }
            if (rotation)
            {
                transform.rotation = target.rotation;
            }
            if (scale)
            {
                transform.localScale = target.localScale;
            }
        }
    }
}