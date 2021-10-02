using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(EasyComment))]
public class EasyCommentEditor : Editor
{
    public SerializedProperty comment;
    bool edit;

    void OnEnable()
    {
        comment = serializedObject.FindProperty("Comment");
    }

    public override void OnInspectorGUI()
    { 
        EditorGUILayout.HelpBox(comment.stringValue, MessageType.None);
        if (GUILayout.Button("Edit"))
        {
            if (!edit)
            {
                edit = true;
            }
            else
            {
                edit = false;
            }
        }

        //GUILayout.TextArea(comment.stringValue);

        if (edit)
        {
            serializedObject.Update();
            comment.stringValue = EditorGUILayout.TextArea(comment.stringValue, GUILayout.MaxHeight(120));
            serializedObject.ApplyModifiedProperties();
        }
        
    }
}
#endif
