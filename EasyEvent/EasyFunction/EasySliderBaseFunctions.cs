using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EasySliderBaseFunctions : MonoBehaviour
{
    Slider slider;
    public UnityEvent minValue;
    public UnityEvent maxValue;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        
    }

    public void AddValue(float addValue)
    {
        slider.value += addValue;
        CheckValues();
    }

    void CheckValues()
    {
        if(slider.value == slider.minValue)
        {
            minValue.Invoke();
        }
        if (slider.value == slider.maxValue)
        {
            maxValue.Invoke();
        }
    }

}