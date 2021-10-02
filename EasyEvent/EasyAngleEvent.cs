using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyAngleEvent : MonoBehaviour
{
    public bool X;
    public Vector2 x_AngleMinMax;
    public UnityEvent x_Event;

    public bool Y;
    public Vector2 y_AngleMinMax;
    public UnityEvent y_Event;

    public bool Z;
    public Vector2 z_AngleMinMax;
    public UnityEvent z_Event;

    private void FixedUpdate()
    {
        if (X)
        {
            if(transform.localEulerAngles.x > x_AngleMinMax.x && transform.localEulerAngles.x < x_AngleMinMax.y)
            {
                x_Event.Invoke();
            }
        }

        if (Y)
        {
            if (transform.localEulerAngles.y > y_AngleMinMax.x && transform.localEulerAngles.y < y_AngleMinMax.y)
            {
                y_Event.Invoke();
            }
        }

        if (Z)
        {
            if (transform.localEulerAngles.z > z_AngleMinMax.x && transform.localEulerAngles.z < z_AngleMinMax.y)
            {
                z_Event.Invoke();
            }
        }
    }
}