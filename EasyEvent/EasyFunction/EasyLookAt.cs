using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLookAt : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5;
    public bool X_Rotation;
    float x;
    public bool Y_Rotation;
    float y;
    public bool Z_Rotation;
    float z;
    public Vector3 DopRot;

    void Update()
    {
        if (X_Rotation) x = target.position.x;
        else x = transform.position.x;

        if (Y_Rotation) y = target.position.y;
        else y = transform.position.y;

        if (Z_Rotation) z = target.position.z;
        else z = transform.position.z;


        Vector3 targVec = new Vector3(x, y, z);
        Vector3 targetDirection = targVec - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.localEulerAngles += DopRot;
    }
}