using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyRotate : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}