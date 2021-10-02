using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyHitDistanceEvent : MonoBehaviour
{
    public Vector3 Direction = new Vector3(0, 0, 1);
    
    public ComparisonType comparisonType = ComparisonType.Less;

    public float distanse;

    public LayerMask layerMask;

    public bool optimized;
    public float callTime = 0.1f;

    public UnityEvent Event;

    public bool isEventActivate;
    
    void Start()
    {
        if (optimized)
        {
            StartCoroutine(optimizedCall());
        }
    }

    void Update()
    {
        if (!optimized) { 
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Direction, out hit, Mathf.Infinity, layerMask))
            {
                if (comparisonType == ComparisonType.Less)
                {
                    if (hit.distance < distanse)
                    {
                        if (!isEventActivate)
                        {
                            Event.Invoke();
                            isEventActivate = true;
                        }
                    }
                    else
                    {
                        isEventActivate = false;
                    }
                }
                if (comparisonType == ComparisonType.Larger)
                {
                    if (hit.distance > distanse)
                    {
                        if (!isEventActivate)
                        {
                            Event.Invoke();
                            isEventActivate = true;
                        }
                    }
                    else
                    {
                        isEventActivate = false;
                    }
                }
            }
        }
    }

    IEnumerator optimizedCall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Direction, out hit, Mathf.Infinity, layerMask))
        {
            if (comparisonType == ComparisonType.Less)
            {
                if (hit.distance < distanse)
                {
                    if (!isEventActivate)
                    {
                        Event.Invoke();
                        isEventActivate = true;
                    }
                }
                else
                {
                    isEventActivate = false;
                }
            }
            if (comparisonType == ComparisonType.Larger)
            {
                if (hit.distance > distanse)
                {
                    if (!isEventActivate)
                    {
                        Event.Invoke();
                        isEventActivate = true;
                    }
                }
                else
                {
                    isEventActivate = false;
                }
            }
        }
        yield return new WaitForSeconds(callTime);
        StartCoroutine(optimizedCall());
    }
}