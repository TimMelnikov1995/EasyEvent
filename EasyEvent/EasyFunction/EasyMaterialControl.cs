using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMaterialControl : MonoBehaviour
{
    Material startMaterial;

    void Start()
    {
        startMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        
    }

    public void setMaterial(Material newMat)
    {
        GetComponent<MeshRenderer>().material = newMat;
    }
    public void resetStartMaterial()
    {
        GetComponent<MeshRenderer>().material = startMaterial;
    }
}