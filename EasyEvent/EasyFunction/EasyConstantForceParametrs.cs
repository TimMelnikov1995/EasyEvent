using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyConstantForceParametrs : MonoBehaviour
{
    public ConstantForce constantForceTarget;

    void Start()
    {
        if (!constantForceTarget)
        {
            constantForceTarget = GetComponent<ConstantForce>();
        }
    }

    public void setRelativeForceX(float value)
    {
        constantForceTarget.relativeForce = new Vector3(value, 0, 0);
    }
    public void setRelativeForceY(float value)
    {
        constantForceTarget.relativeForce = new Vector3(0, value, 0);
    }
    public void setRelativeForceZ(float value)
    {
        constantForceTarget.relativeForce = new Vector3(0, 0, value);
    }
}