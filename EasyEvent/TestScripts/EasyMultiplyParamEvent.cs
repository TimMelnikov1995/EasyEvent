using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/*[CustomPropertyDrawer(typeof(Objects), true)]
public class ObjectsEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var amountRect = new Rect(position.x, position.y, 50, position.height);
        //var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        //var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("f"), GUIContent.none);
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("objects"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}*/

public class EasyMultiplyParamEvent : MonoBehaviour
{
    public GameObject EventObject;
    [listToPopup(typeof(EasyMultiplyParamEvent), "myComponentsList")]
    public string EventComponent;
    [listToPopup(typeof(EasyMultiplyParamEvent), "myMethodList")]
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

    public void update()
    {
        if (EventObject)
        {
            getEventObjectComponents();
            getEventComponentMethod();

            if (EventMethod != null && myMethodList != null && EventComponent != null && EventComponent != " ")
            {
                ParametersLength = EventObject.GetComponent(EventComponent).GetType().GetMethod(EventMethod).GetParameters().Length;
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

                Type _type = EventObject.GetComponent(EventComponent).GetType().GetMethod(EventMethod).GetParameters()[i].ParameterType;

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

    void getEventObjectComponents()
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
    }

    void getEventComponentMethod()
    {
        if (EventComponent != null && EventComponent != " ")
        {
            string[] EC_split = EventComponent.Split('.');
            if (EC_split[0] != "UnityEngine")
            {
                myMethodList = new List<string> { };
                if (EventObject.GetComponent(EventComponent).GetType().GetMethods().Length > 0)
                {
                    for (int i = 0; i < EventObject.GetComponent(EventComponent).GetType().GetMethods().Length; i++)
                    {
                        myMethodList.Add(" ");
                        myMethodList[i] = EventObject.GetComponent(EventComponent).GetType().GetMethods()[i].Name;
                    }
                }
            }
            else
            {
                myMethodList = new List<string> {null };
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

    public void _Invoke()
    {
        //print(EventObject.GetComponent(EventComponent).GetType().GetMethod(EventMethod).GetParameters().Length);
        //print(EventObject.GetComponent(EventComponent).GetType().GetMethod(EventMethod).GetParameters()[0].ParameterType);

        var loadingMethod = EventObject.GetComponent(EventComponent).GetType().GetMethod(EventMethod);
        loadingMethod.Invoke(EventObject.GetComponent(EventComponent), _objects);
    }
}