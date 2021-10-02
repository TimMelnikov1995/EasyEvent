using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyInstantiate : MonoBehaviour
{
    public GameObject InstantiateObject;
    public Transform InstantiatePoint;
    public Transform InstantiateObjectParent;

    public void _Instantiate()
    {
        GameObject NewGo = Instantiate(InstantiateObject);
        NewGo.transform.position = InstantiatePoint.position;
        NewGo.transform.rotation = InstantiatePoint.rotation;
        if(InstantiateObjectParent != null)
        {
            NewGo.transform.parent = InstantiateObjectParent;
        }
    }
}