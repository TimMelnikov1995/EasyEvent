using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class listToPopupAttribute : PropertyAttribute
{
    public Type myType;
    public string propertyName;
    public listToPopupAttribute(Type _myType, string _propertyName)
    {
        myType = _myType;
        propertyName = _propertyName;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(listToPopupAttribute))]
public class ListToPopupDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        listToPopupAttribute atb = attribute as listToPopupAttribute;
        List<string> stringList = null;

        if (atb.myType.GetField(atb.propertyName) != null)
        {
            stringList = atb.myType.GetField(atb.propertyName).GetValue(atb.myType) as List<string>;
        }

        if (stringList != null && stringList.Count != 0)
        {
            int selectedIndex = Math.Max(stringList.IndexOf(property.stringValue), 0);
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, stringList.ToArray());
            property.stringValue = stringList[selectedIndex];
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
#endif