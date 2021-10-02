using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(EasyNoObjectEvent))]
[CanEditMultipleObjects]
public class EasyNoObjectEventEditor : Editor
{
    //SerializedProperty EventObject;
    //SerializedProperty _objects;
    SerializedProperty EventComponent;
    SerializedProperty EventMethod;

    SerializedProperty ParametersLength;

    SerializedProperty GO;
    SerializedProperty intValues;
    SerializedProperty floatValues;
    SerializedProperty stringValues;
    SerializedProperty GoValues;
    SerializedProperty TransformValues;
    SerializedProperty Vector2Values;
    SerializedProperty Vector3Values;
    SerializedProperty Vector4Values;
    //SerializedProperty QuaternionValues;

    void OnEnable()
    {
        //EventObject = serializedObject.FindProperty("EventObject");
        //_objects = serializedObject.FindProperty("_objects");
        EventComponent = serializedObject.FindProperty("EventComponent");
        EventMethod = serializedObject.FindProperty("EventMethod");

        ParametersLength = serializedObject.FindProperty("ParametersLength");


        GO = serializedObject.FindProperty("GO");
        intValues = serializedObject.FindProperty("intValues");
        floatValues = serializedObject.FindProperty("floatValues");
        stringValues = serializedObject.FindProperty("stringValues");
        GoValues = serializedObject.FindProperty("GoValues");
        TransformValues = serializedObject.FindProperty("TransformValues");
        Vector2Values = serializedObject.FindProperty("Vector2Values");
        Vector3Values = serializedObject.FindProperty("Vector3Values");
        Vector4Values = serializedObject.FindProperty("Vector4Values");
        //QuaternionValues = serializedObject.FindProperty("QuaternionValues");
    }

    public override void OnInspectorGUI()
    {
        var t = (target as EasyNoObjectEvent);

        serializedObject.Update();
        //EditorGUILayout.PropertyField(EventObject);

        EditorGUILayout.PropertyField(EventComponent);
        serializedObject.ApplyModifiedProperties();
        t.updateComponentType();

        if (t.ComponentType != null)
        {
            EditorGUILayout.PropertyField(EventMethod);
        }
        serializedObject.ApplyModifiedProperties();

        t.update();

        if (t.ComponentType != null)
        {
            if (ParametersLength.intValue > 0 && t.EventComponent != null && EventMethod.stringValue != null)
            {
                for (int i = 0; i < ParametersLength.intValue; i++)
                {

                    System.Type _type = t.ComponentType.GetMethod(EventMethod.stringValue).GetParameters()[i].ParameterType;

                    if (_type == typeof(int))
                    {
                        EditorGUILayout.PropertyField(intValues.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(float))
                    {
                        EditorGUILayout.PropertyField(floatValues.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(string))
                    {
                        EditorGUILayout.PropertyField(stringValues.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(GameObject))
                    {
                        EditorGUILayout.PropertyField(GoValues.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(Transform))
                    {
                        EditorGUILayout.PropertyField(TransformValues.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(Vector2))
                    {
                        EditorGUILayout.PropertyField(Vector2Values.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(Vector3))
                    {
                        EditorGUILayout.PropertyField(Vector3Values.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(Vector4))
                    {
                        EditorGUILayout.PropertyField(Vector4Values.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }
                    else if (_type == typeof(Quaternion))
                    {
                        //EditorGUILayout.PropertyField(QuaternionValues.GetArrayElementAtIndex(i));
                        //t.type[i] = _type;
                        EditorGUILayout.HelpBox("Quaternion is not supported", MessageType.Error);
                    }


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
                        EditorGUILayout.PropertyField(GO.GetArrayElementAtIndex(i));
                        t.type[i] = _type;
                    }

                    serializedObject.ApplyModifiedProperties();
                    t.setEventParametrs();
                }
            }
        }
    }
}
#endif