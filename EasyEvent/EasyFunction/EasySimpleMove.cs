using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySimpleMove : MonoBehaviour
{
    public Vector3 moveDirection;
    public float moveSpeed;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.localPosition += moveDirection * moveSpeed;
    }
}