using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyDistanseEvent : MonoBehaviour
{
    public Transform target;
    public ComparisonType comparisonType = ComparisonType.Less;
    public float distanse;
    public bool optimized;
    public float callTime = 0.1f;
    public UnityEvent Event;
    public bool isEventActivate;
    float distToTarget;

    

    private void Start()
    {
        if (optimized)
        {
            StartCoroutine(optimizedCall());
        }
    }

    private void OnEnable()
    {
        if (optimized)
        {
            StartCoroutine(optimizedCall());
        }
    }

    void Update()
    {
        if (!optimized)
        {
            distToTarget = Vector3.Distance(transform.position, target.position);

            if (comparisonType == ComparisonType.Less)
            {
                if (distToTarget < distanse)
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
                if (distToTarget > distanse)
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
    IEnumerator optimizedCall()
    {
        distToTarget = Vector3.Distance(transform.position, target.position);

        if (comparisonType == ComparisonType.Less)
        {
            if (distToTarget < distanse)
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
            if (distToTarget > distanse)
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
        yield return new WaitForSeconds(callTime);
        StartCoroutine(optimizedCall());
    }
}