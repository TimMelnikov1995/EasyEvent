using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EasySmoothFloat : MonoBehaviour
{
    public Vector2 From_To;
    [HideInInspector]
    public float Run;
    bool XLargeY;
    bool XEqualY;
    public float speed;
    public DynamicFloatEvent ValueToChange;
    public UnityEvent OnFinishRun;

    [HideInInspector]
    public bool isScript;
    [HideInInspector]
    public float Float
    {
        get
        {
            return Run;
        }
    }

    void OnEnable()
    {
        Run = From_To.x;
        checkLargeOrLess();
    }

    void checkLargeOrLess()
    {
        if(From_To.x == From_To.y)
        {
            XEqualY = true;
        }
        else if (From_To.x > From_To.y)
        {
            XEqualY = false;
            XLargeY = true;
        }
        else if(From_To.x < From_To.y)
        {
            XEqualY = false;
            XLargeY = false;
        }
    }

    public void ChangeValueFrom(float newValue)
    {
        gameObject.SetActive(true);
        From_To.x = newValue;
        checkLargeOrLess();
    }
    public void ChangeValueTo(float newValue)
    {
        gameObject.SetActive(true);
        From_To.y = newValue;
        checkLargeOrLess();
    }

    private void FixedUpdate()
    {
        if (XLargeY)
        {
            if (!XEqualY)
            {
                Run -= Time.fixedDeltaTime * speed;
            }
            if (!isScript)
            {
                ValueToChange.Invoke(Run);
            }
            if (Run <= From_To.y)
            {
                if (!isScript)
                {
                    OnFinishRun.Invoke();
                }
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (!XEqualY)
            {
                Run += Time.fixedDeltaTime * speed;
            }
            if (!isScript)
            {
                ValueToChange.Invoke(Run);
            }
            if (Run >= From_To.y)
            {
                if (!isScript)
                {
                    OnFinishRun.Invoke();
                }
                gameObject.SetActive(false);
            }
        }
    }

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    public void changeFloatFromTo(float from, float to)
    {
        From_To = new Vector2(from, to);
        gameObject.SetActive(true);
        checkLargeOrLess();
    }
}