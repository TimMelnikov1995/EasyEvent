using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGoBaseFunctions : MonoBehaviour
{
    public void setActiveTrue()
    {
        gameObject.SetActive(true);
    }
    public void setActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    public void setLocalPosX(float newValue)
    {
        transform.localPosition = new Vector3(newValue, transform.localPosition.y, transform.localPosition.z);
    }
    public void setLocalPosY(float newValue)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, newValue, transform.localPosition.z);
    }
    public void setLocalPosZ(float newValue)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newValue);
    }

    public void AddLocalPosX(float addValue)
    {
        transform.localPosition += new Vector3(addValue, 0, 0);
    }
    public void AddLocalPosY(float addValue)
    {
        transform.localPosition += new Vector3(0, addValue, 0);
    }
    public void AddLocalPosZ(float addValue)
    {
        transform.localPosition += new Vector3(0, 0, addValue);
    }

    public void setEulerAnglesX(float newValue)
    {
        transform.eulerAngles = new Vector3(newValue, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    public void setEulerAnglesY(float newValue)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, newValue, transform.eulerAngles.z);
    }
    public void setEulerAnglesZ(float newValue)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newValue);
    }

    public void AddLocalRotX(float addValue)
    {
        transform.localEulerAngles += new Vector3(addValue, 0, 0);
    }
    public void AddLocalRotY(float addValue)
    {
        transform.localEulerAngles += new Vector3(0, addValue, 0);
    }
    public void AddLocalRotZ(float addValue)
    {
        transform.localEulerAngles += new Vector3(0, 0, addValue);
    }

    public void setPosX(float newValue)
    {
        transform.position = new Vector3(newValue, transform.position.y, transform.position.z);
    }
    public void setPosY(float newValue)
    {
        transform.position = new Vector3(transform.position.x, newValue, transform.position.z);
    }
    public void setPosZ(float newValue)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, newValue);
    }

    public void CopyTargetPos(Transform target)
    {
        transform.position = target.position;
    }
    public void CopyTargetRot(Transform target)
    {
        transform.rotation = target.rotation;
    }

    public void setParent(Transform newParent)
    {
        if (newParent == null)
        {
            transform.parent = null;
        }
        else
        {
            transform.parent = newParent;
        }
    }

    public void setTag(string newTag)
    {
        gameObject.tag = newTag;
    }
}