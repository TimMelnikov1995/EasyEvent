using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EasyMoveTowards : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public UnityEvent OnGoalTagret;
    bool IsGoalTarget;

    private void Update()
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(transform.position == target.position)
            {
                if (!IsGoalTarget)
                {
                    OnGoalTagret.Invoke();
                    IsGoalTarget = true;
                }
            }
            else
            {
                IsGoalTarget = false;
            }
        }
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void setSpeed(float value)
    {
        speed = value;
    }
}