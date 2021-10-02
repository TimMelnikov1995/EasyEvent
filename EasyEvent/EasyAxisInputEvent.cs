using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DynamicFloatEvent : UnityEvent<float> { }
public class EasyAxisInputEvent : MonoBehaviour
{
    [Tooltip("Имя вертикальной оси")]
    public string VAxisName = "Vertical";
    [Tooltip("Имя горизонтальной оси")]
    public string HAxisName = "Horizontal";
    [Tooltip("Множитель оси по вертикали")]
    public float VAxisForce = 1;
    [Tooltip("Множитель оси по горизонтали")]
    public float HAxisForce = 1;

    [Tooltip("Флаг управления ИИ")]
    public bool isAI;
    [Tooltip("Обьект, локальное положение которого, будет являться для ИИ джойстиком")]
    public Transform AI_VirtualJoystick;

    [Tooltip("Динамическое событие для вертикальной оси")]
    public DynamicFloatEvent VAxis;
    [Tooltip("Динамическое событие для горизонтальной оси")]
    public DynamicFloatEvent HAxis;
    [Tooltip("Событие вызывается когда хотя бы одна ось не равна нулю")]
    public DynamicFloatEvent OnChangeAnyAxis;

    float v; // переменная в которой будет храниться ввод игрока/ИИ по вертикальной оси
    float h; // переменная в которой будет храниться ввод игрока/ИИ по горизонтальной оси

    bool isNull;

    

    void FixedUpdate()
    {
        if (!isAI) // если упраление производит игрок
        {
            v = Input.GetAxis(VAxisName) * VAxisForce; // присваиваем переменной v значение ввода по вертикальной оси и умножаем на множитель этой оси заданный ранее
            h = Input.GetAxis(HAxisName) * HAxisForce; // присваиваем переменной h значение ввода по горизонтальной оси и умножаем на множитель этой оси заданный ранее
        }
        else // если управление производит ИИ
        {
            v = AI_VirtualJoystick.localPosition.z;
            h = AI_VirtualJoystick.localPosition.x;
        }

        VAxis.Invoke(Mathf.Clamp(v, -VAxisForce, VAxisForce));
        HAxis.Invoke(Mathf.Clamp(h, -HAxisForce, HAxisForce));

        if (v == 0 && h == 0)
        {
            isNull = true;
        }
        else
        {
            isNull = false;
        }

        if (!isNull)
        {
            if (Mathf.Abs(v) > Mathf.Abs(h))
            {
                OnChangeAnyAxis.Invoke(Mathf.Abs(Mathf.Clamp(v, -VAxisForce, VAxisForce)));
            }
            else
            {
                OnChangeAnyAxis.Invoke(Mathf.Abs(Mathf.Clamp(h, -HAxisForce, HAxisForce)));
            }
        }
    }
}