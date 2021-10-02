using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyAddForce : MonoBehaviour
{
    [Tooltip("Если это поле оставить пустым, то при запуске автоматически будет взять Rigidbody с объекта, на котором висит этот скрипт")]
    public Rigidbody AddForceTarget;

    void Start()
    {
        if (!AddForceTarget)
        {
            AddForceTarget = GetComponent<Rigidbody>();
        }
    }

    public void AddForceX(float force)
    {
        AddForceTarget.AddRelativeForce(force, 0, 0, ForceMode.Force);
    }
    public void AddForceY(float force)
    {
        AddForceTarget.AddRelativeForce(0, force, 0, ForceMode.Force);
    }
    public void AddForceZ(float force)
    {
        AddForceTarget.AddRelativeForce(0, 0, force, ForceMode.Force);
    }

    public void AddImpulseX(float force)
    {
        AddForceTarget.AddRelativeForce(force, 0, 0, ForceMode.Impulse);
    }
    public void AddImpulseY(float force)
    {
        AddForceTarget.AddRelativeForce(0, force, 0, ForceMode.Impulse);
    }
    public void AddImpulseZ(float force)
    {
        AddForceTarget.AddRelativeForce(0, 0, force, ForceMode.Impulse);
    }

    public void AddTorqueX(float force)
    {
        AddForceTarget.AddRelativeTorque(force, 0, 0, ForceMode.Force);
    }
    public void AddTorqueY(float force)
    {
        AddForceTarget.AddRelativeTorque(0, force, 0, ForceMode.Force);
    }
    public void AddTorqueZ(float force)
    {
        AddForceTarget.AddRelativeTorque(0, 0, force, ForceMode.Force);
    }

    public void setAddForceTarget(Rigidbody newTarget)
    {
        AddForceTarget = newTarget;
    }
}