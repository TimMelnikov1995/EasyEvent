using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EasyNoObjectEvent : MonoBehaviour
{
    //public GameObject EventObject;

    public Type ComponentType;

    //[listToPopup(typeof(EasyMultiplyParamEvent), "myComponentsList")]
    public string EventComponent;
    [listToPopup(typeof(EasyNoObjectEvent), "myMethodList")]
    public string EventMethod;
    public object[] _objects = new object[10];

    public static List<string> myComponentsList;
    public static List<string> myMethodList;

    public int ParametersLength;

    public GameObject[] GO = new GameObject[5];
    public Type[] type = new Type[5];

    public int[] intValues = new int[5];
    public float[] floatValues = new float[5];
    public string[] stringValues = new string[5];
    public GameObject[] GoValues = new GameObject[5];
    public Transform[] TransformValues = new Transform[5];
    public Vector2[] Vector2Values = new Vector2[5];
    public Vector3[] Vector3Values = new Vector3[5];
    public Vector4[] Vector4Values = new Vector4[5];
    //public Quaternion[] QuaternionValues = new Quaternion[5];


    [ContextMenu("updateType")]
    public void updateComponentType()
    {
        if (EventComponent != null && EventComponent != "")
        {
            ComponentType = Type.GetType(EventComponent);
        }
    }


    public void update()
    {
        updateComponentType();

        if (ComponentType != null)
        {
            //getEventObjectComponents();
            getEventComponentMethod();

            if (EventMethod != "" && EventMethod != null && myMethodList != null && EventComponent != null)
            {
                ParametersLength = ComponentType.GetMethod(EventMethod).GetParameters().Length;
            }
            _objects = new object[ParametersLength];
        }
    }
    private void Start()
    {
        update();
        updateType();
        setEventParametrs();
    }

    void updateType()
    {
        if (ParametersLength > 0)
        {
            for (int i = 0; i < ParametersLength; i++)
            {

                Type _type = ComponentType.GetMethod(EventMethod).GetParameters()[i].ParameterType;

                //t._objects = new object[ParametersLength.intValue];

                if (_type == typeof(int))
                {
                    //EditorGUILayout.PropertyField(intValues[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(float))
                {
                    //EditorGUILayout.PropertyField(floatValues[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(string))
                {
                    //EditorGUILayout.PropertyField(stringValues[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(GameObject))
                {
                    //EditorGUILayout.PropertyField(GoValues[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(Transform))
                {
                    //EditorGUILayout.PropertyField(TransformValues[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(Vector2))
                {
                    //EditorGUILayout.PropertyField(Vector2Values[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(Vector3))
                {
                    //EditorGUILayout.PropertyField(Vector3Values[i]);
                    type[i] = _type;
                }
                else if (_type == typeof(Vector4))
                {
                    //EditorGUILayout.PropertyField(Vector4Values[i]);
                    type[i] = _type;
                }
                /*else if (_type == typeof(Quaternion))
                {
                    //EditorGUILayout.PropertyField(QuaternionValues.GetArrayElementAtIndex(i));
                    //t.type[i] = _type;
                    EditorGUILayout.HelpBox("Quaternion is not supported", MessageType.Error);
                }*/


                else if (_type != typeof(int)
                    && _type != typeof(float)
                    && _type != typeof(string)
                    && _type != typeof(GameObject)
                    && _type != typeof(Transform)
                    && _type != typeof(Vector2)
                    && _type != typeof(Vector3)
                    && _type != typeof(Vector4)
                    && _type != typeof(Quaternion))
                {
                    //EditorGUILayout.PropertyField(GO.GetArrayElementAtIndex(i));
                    type[i] = _type;
                }
            }
        }
    }

    /*void getEventObjectComponents()
    {
        if (EventObject != null)
        {
            myComponentsList = new List<string> { };
            for (int i = 0; i < EventObject.GetComponents(typeof(Component)).Length; i++)
            {
                string[] EC_split = EventObject.GetComponents(typeof(Component))[i].GetType().ToString().Split('.');
                //print(EC_split[0]);
                myComponentsList.Add(" ");
                if (EC_split[0] != "UnityEngine")
                {

                    myComponentsList[i] = EventObject.GetComponents(typeof(Component))[i].GetType().ToString();
                }
            }
        }
    }*/

    void getEventComponentMethod()
    {
        if (EventComponent != null && EventComponent != " ")
        {
            string[] EC_split = EventComponent.Split('.');
            if (EC_split[0] != "UnityEngine")
            {
                myMethodList = new List<string> { };
                if (ComponentType.GetMethods().Length > 0)
                {
                    for (int i = 0; i < ComponentType.GetMethods().Length; i++)
                    {
                        myMethodList.Add(" ");
                        myMethodList[i] = ComponentType.GetMethods()[i].Name;
                    }
                }
            }
            else
            {
                myMethodList = new List<string> { null };
                EventMethod = null;
            }
        }
    }

    public void setEventParametrs()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (type[i] == typeof(int))
            {
                _objects[i] = intValues[i];
            }
            else if (type[i] == typeof(float))
            {
                _objects[i] = floatValues[i];
            }
            else if (type[i] == typeof(string))
            {
                _objects[i] = stringValues[i];
            }
            else if (type[i] == typeof(GameObject))
            {
                _objects[i] = GoValues[i];
            }
            else if (type[i] == typeof(Transform))
            {
                _objects[i] = TransformValues[i];
            }
            else if (type[i] == typeof(Vector2))
            {
                _objects[i] = Vector2Values[i];
            }
            else if (type[i] == typeof(Vector3))
            {
                _objects[i] = Vector3Values[i];
            }
            else if (type[i] == typeof(Vector4))
            {
                _objects[i] = Vector4Values[i];
            }
            /*else if (type[i] == typeof(Quaternion))
            {
                _objects.objects[i] = QuaternionValues[i];
            }*/

            else if (type[i] != typeof(int)
                        && type[i] != typeof(float)
                        && type[i] != typeof(string)
                        && type[i] != typeof(GameObject)
                        && type[i] != typeof(Transform)
                        && type[i] != typeof(Vector2)
                        && type[i] != typeof(Vector3)
                        && type[i] != typeof(Vector4)
                        && type[i] != typeof(Quaternion))
            {
                _objects[i] = GO[i].GetComponent(type[i]);
            }
        }
    }

    public void _Invoke(GameObject _eventObject)
    {
        if (_eventObject.GetComponent(EventComponent))
        {
            var loadingMethod = ComponentType.GetMethod(EventMethod);
            loadingMethod.Invoke(_eventObject.GetComponent(EventComponent), _objects);
        }
    }
}