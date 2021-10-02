using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class EasyInputEvent : MonoBehaviour
{
    public KeyCode Key;
    public bool isAI;
    public UnityEvent OnKeyDown;
    public UnityEvent OnKey;
    public UnityEvent OnKeyUp;

    public List<EasyMultiplyParamEvent> easyMultiplyParamEventsOnKeyDown = new List<EasyMultiplyParamEvent>(0);
    public List<EasyMultiplyParamEvent> easyMultiplyParamEventsOnKey = new List<EasyMultiplyParamEvent>(0);
    public List<EasyMultiplyParamEvent> easyMultiplyParamEventsOnKeyUp = new List<EasyMultiplyParamEvent>(0);

    //public List<testClass> tests;

    void Update()
    {
        if (!isAI)
        {
            if (Input.GetKeyDown(Key))
            {
                _onKeyDown();
            }
            if (Input.GetKey(Key))
            {
                _onKey();
            }
            if (Input.GetKeyUp(Key))
            {
                _onKeyUp();
            }
        }
    }

    public void _onKeyDown()
    {
        OnKeyDown.Invoke();
        if(easyMultiplyParamEventsOnKeyDown.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEventsOnKeyDown.Count; i++)
            {
                easyMultiplyParamEventsOnKeyDown[i]._Invoke();
            }
        }
    }
    public void _onKey()
    {
        OnKey.Invoke();
        if (easyMultiplyParamEventsOnKey.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEventsOnKey.Count; i++)
            {
                easyMultiplyParamEventsOnKey[i]._Invoke();
            }
        }
    }
    public void _onKeyUp()
    {
        OnKeyUp.Invoke();
        if (easyMultiplyParamEventsOnKeyUp.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEventsOnKeyUp.Count; i++)
            {
                easyMultiplyParamEventsOnKeyUp[i]._Invoke();
            }
        }
    }

    void addMultiplyEventOnKeyDown()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("OnKeyDown_MultyplayEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEventsOnKeyDown.Add(newEvent);

    }

    void addMultiplyEventOnKey()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("OnKey_MultyplayEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEventsOnKey.Add(newEvent);
    }

    void addMultiplyEventOnKeyUp()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("OnKeyUp_MultyplayEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEventsOnKeyUp.Add(newEvent);
    }

    void updateMultiplyEvents()
    {
        for(int i = 0; i < easyMultiplyParamEventsOnKeyDown.Count; i++)
        {
            if (!easyMultiplyParamEventsOnKeyDown[i])
            {
                easyMultiplyParamEventsOnKeyDown.RemoveAt(i);
            }
        }

        for (int i = 0; i < easyMultiplyParamEventsOnKey.Count; i++)
        {
            if (!easyMultiplyParamEventsOnKey[i])
            {
                easyMultiplyParamEventsOnKey.RemoveAt(i);
            }
        }

        for (int i = 0; i < easyMultiplyParamEventsOnKeyUp.Count; i++)
        {
            if (!easyMultiplyParamEventsOnKeyUp[i])
            {
                easyMultiplyParamEventsOnKeyUp.RemoveAt(i);
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EasyInputEvent))]
    [CanEditMultipleObjects]
    class EasyInputEventEditor : Editor
    {
        SerializedProperty Key;
        SerializedProperty isAI;
        SerializedProperty OnKeyDown;
        SerializedProperty OnKey;
        SerializedProperty OnKeyUp;

        private void OnEnable()
        {
            Key = serializedObject.FindProperty("Key");
            isAI = serializedObject.FindProperty("isAI");
            OnKeyDown = serializedObject.FindProperty("OnKeyDown");
            OnKey = serializedObject.FindProperty("OnKey");
            OnKeyUp = serializedObject.FindProperty("OnKeyUp");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var t = (target as EasyInputEvent);

            EditorGUILayout.PropertyField(Key);
            EditorGUILayout.PropertyField(isAI);
            EditorGUILayout.PropertyField(OnKeyDown);
            if (t.easyMultiplyParamEventsOnKeyDown != null)
            {
                if (t.easyMultiplyParamEventsOnKeyDown.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnKeyDown Multiply Events Count\n" + t.easyMultiplyParamEventsOnKeyDown.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Event OnKeyDown"))
            {
                t.addMultiplyEventOnKeyDown();
            }
            
            EditorGUILayout.PropertyField(OnKey);
            if (t.easyMultiplyParamEventsOnKey != null)
            {
                if (t.easyMultiplyParamEventsOnKey.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnKey Multiply Events Count\n" + t.easyMultiplyParamEventsOnKey.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Event OnKey"))
            {
                t.addMultiplyEventOnKey();
            }
            
            EditorGUILayout.PropertyField(OnKeyUp);
            if (t.easyMultiplyParamEventsOnKeyUp != null)
            {
                if (t.easyMultiplyParamEventsOnKeyUp.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnKeyUp Multiply Events Count\n" + t.easyMultiplyParamEventsOnKeyUp.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Event OnKeyUp"))
            {
                t.addMultiplyEventOnKeyUp();
            }

            serializedObject.ApplyModifiedProperties();
            t.updateMultiplyEvents();
        }
    }
#endif
}