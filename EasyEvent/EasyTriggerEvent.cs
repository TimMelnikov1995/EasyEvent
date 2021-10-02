using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class EasyTriggerEvent : MonoBehaviour
{
    public EasyTagMask tags;

    public UnityEvent OnEnter;
    public string OnEnterMethodName = "";
    public UnityEvent OnStay;
    public string OnStayMethodName = "";
    public UnityEvent OnExit;
    public string OnExitMethodName = "";

    public List<EasyMultiplyParamEvent> easyMultiplyParamEventsOnEnter = new List<EasyMultiplyParamEvent>(0);
    public List<EasyMultiplyParamEvent> easyMultiplyParamEventsOnStay = new List<EasyMultiplyParamEvent>(0);
    public List<EasyMultiplyParamEvent> easyMultiplyParamEventsOnExit = new List<EasyMultiplyParamEvent>(0);

    public List<EasyNoObjectEvent> easyNoObjectEventsOnEnter = new List<EasyNoObjectEvent>(0);
    public List<EasyNoObjectEvent> easyNoObjectEventsOnStay = new List<EasyNoObjectEvent>(0);
    public List<EasyNoObjectEvent> easyNoObjectEventsOnExit = new List<EasyNoObjectEvent>(0);

    public GameObject OtherCollider;

    public void onEnterEvent()
    {
        OnEnter.Invoke();
        if (easyMultiplyParamEventsOnEnter.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEventsOnEnter.Count; i++)
            {
                easyMultiplyParamEventsOnEnter[i]._Invoke();
            }
        }
        if (OtherCollider)
        {
            if (easyNoObjectEventsOnEnter.Count > 0)
            {
                for (int i = 0; i < easyNoObjectEventsOnEnter.Count; i++)
                {
                    easyNoObjectEventsOnEnter[i]._Invoke(OtherCollider);
                }
            }
        }
    }
    public void onStayEvent()
    {
        OnStay.Invoke();
        if (easyMultiplyParamEventsOnStay.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEventsOnStay.Count; i++)
            {
                easyMultiplyParamEventsOnStay[i]._Invoke();
            }
        }
        if (OtherCollider)
        {
            if (easyNoObjectEventsOnStay.Count > 0)
            {
                for (int i = 0; i < easyNoObjectEventsOnStay.Count; i++)
                {
                    easyNoObjectEventsOnStay[i]._Invoke(OtherCollider);
                }
            }
        }
    }
    public void onExitEvent()
    {
        OnExit.Invoke();
        if (easyMultiplyParamEventsOnExit.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEventsOnExit.Count; i++)
            {
                easyMultiplyParamEventsOnExit[i]._Invoke();
            }
        }
        if (OtherCollider)
        {
            if (easyNoObjectEventsOnExit.Count > 0)
            {
                for (int i = 0; i < easyNoObjectEventsOnExit.Count; i++)
                {
                    easyNoObjectEventsOnExit[i]._Invoke(OtherCollider);
                }
            }
        }
    }

    void addMultiplyEventOnEnter()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("OnEnter_MultyplayEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEventsOnEnter.Add(newEvent);
    }

    void addMultiplyEventStay()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("OnStay_MultyplayEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEventsOnStay.Add(newEvent);
    }

    void addMultiplyEventOnExit()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("OnExit_MultyplayEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEventsOnExit.Add(newEvent);
    }

    void updateMultiplyEvents()
    {
        for (int i = 0; i < easyMultiplyParamEventsOnEnter.Count; i++)
        {
            if (!easyMultiplyParamEventsOnEnter[i])
            {
                easyMultiplyParamEventsOnEnter.RemoveAt(i);
            }
        }

        for (int i = 0; i < easyMultiplyParamEventsOnStay.Count; i++)
        {
            if (!easyMultiplyParamEventsOnStay[i])
            {
                easyMultiplyParamEventsOnStay.RemoveAt(i);
            }
        }

        for (int i = 0; i < easyMultiplyParamEventsOnExit.Count; i++)
        {
            if (!easyMultiplyParamEventsOnExit[i])
            {
                easyMultiplyParamEventsOnExit.RemoveAt(i);
            }
        }
    }


    void addNoObjectEventOnEnter()
    {
        EasyNoObjectEvent newEvent = new GameObject("OnEnter_NoObjectEvent").AddComponent<EasyNoObjectEvent>();
        newEvent.transform.parent = transform;
        easyNoObjectEventsOnEnter.Add(newEvent);
    }

    void addNoObjectEventStay()
    {
        EasyNoObjectEvent newEvent = new GameObject("OnStay_NoObjectEvent").AddComponent<EasyNoObjectEvent>();
        newEvent.transform.parent = transform;
        easyNoObjectEventsOnStay.Add(newEvent);
    }

    void addNoObjectEventOnExit()
    {
        EasyNoObjectEvent newEvent = new GameObject("OnExit_NoObjectEvent").AddComponent<EasyNoObjectEvent>();
        newEvent.transform.parent = transform;
        easyNoObjectEventsOnExit.Add(newEvent);
    }

    void updateNoObjectEvents()
    {
        for (int i = 0; i < easyNoObjectEventsOnEnter.Count; i++)
        {
            if (!easyNoObjectEventsOnEnter[i])
            {
                easyNoObjectEventsOnEnter.RemoveAt(i);
            }
        }

        for (int i = 0; i < easyNoObjectEventsOnStay.Count; i++)
        {
            if (!easyNoObjectEventsOnStay[i])
            {
                easyNoObjectEventsOnStay.RemoveAt(i);
            }
        }

        for (int i = 0; i < easyNoObjectEventsOnExit.Count; i++)
        {
            if (!easyNoObjectEventsOnExit[i])
            {
                easyNoObjectEventsOnExit.RemoveAt(i);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(tags.Contains(other.tag))
        {
            OtherCollider = other.gameObject;
            onEnterEvent();
            if(OnEnterMethodName != "")
            {
                other.gameObject.SendMessage(OnEnterMethodName);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            OtherCollider = other.gameObject;
            onStayEvent();
            if (OnStayMethodName != "")
            {
                other.gameObject.SendMessage(OnStayMethodName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            OtherCollider = other.gameObject;
            onExitEvent();
            if (OnExitMethodName != "")
            {
                other.gameObject.SendMessage(OnExitMethodName);
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EasyTriggerEvent))]
    [CanEditMultipleObjects]
    class EasyTriggerEventEditor : Editor
    {
        SerializedProperty tags;
        SerializedProperty OnEnter;
        SerializedProperty OnEnterMethodName;
        SerializedProperty OnStay;
        SerializedProperty OnStayMethodName;
        SerializedProperty OnExit;
        SerializedProperty OnExitMethodName;

        private void OnEnable()
        {
            tags = serializedObject.FindProperty("tags");
            OnEnter = serializedObject.FindProperty("OnEnter");
            OnEnterMethodName = serializedObject.FindProperty("OnEnterMethodName");
            OnStay = serializedObject.FindProperty("OnStay");
            OnStayMethodName = serializedObject.FindProperty("OnStayMethodName");
            OnExit = serializedObject.FindProperty("OnExit");
            OnExitMethodName = serializedObject.FindProperty("OnExitMethodName");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var t = (target as EasyTriggerEvent);

            EditorGUILayout.PropertyField(tags);
            EditorGUILayout.PropertyField(OnEnter);
            EditorGUILayout.PropertyField(OnEnterMethodName);
            if (t.easyMultiplyParamEventsOnEnter != null)
            {
                if (t.easyMultiplyParamEventsOnEnter.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnEnter Multiply Events Count\n" + t.easyMultiplyParamEventsOnEnter.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Event OnEnter"))
            {
                t.addMultiplyEventOnEnter();
            }

            if (t.easyNoObjectEventsOnEnter != null)
            {
                if (t.easyNoObjectEventsOnEnter.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnEnter NoObject Events Count\n" + t.easyNoObjectEventsOnEnter.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add NoObject Event OnEnter"))
            {
                t.addNoObjectEventOnEnter();
            }

            EditorGUILayout.PropertyField(OnStay);
            EditorGUILayout.PropertyField(OnStayMethodName);
            if (t.easyMultiplyParamEventsOnStay != null)
            {
                if (t.easyMultiplyParamEventsOnStay.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnStay Myltiply Events Count\n" + t.easyMultiplyParamEventsOnStay.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Event OnStay"))
            {
                t.addMultiplyEventStay();
            }

            if (t.easyNoObjectEventsOnStay != null)
            {
                if (t.easyNoObjectEventsOnStay.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnStay NoObject Events Count\n" + t.easyNoObjectEventsOnStay.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add NoObject Event OnStay"))
            {
                t.addNoObjectEventStay();
            }

            EditorGUILayout.PropertyField(OnExit);
            EditorGUILayout.PropertyField(OnExitMethodName);
            if (t.easyMultiplyParamEventsOnExit != null)
            {
                if (t.easyMultiplyParamEventsOnExit.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnExit Myltiply Events Count\n" + t.easyMultiplyParamEventsOnExit.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Event OnExit"))
            {
                t.addMultiplyEventOnExit();
            }

            if (t.easyNoObjectEventsOnExit != null)
            {
                if (t.easyNoObjectEventsOnExit.Count > 0)
                {
                    EditorGUILayout.HelpBox("OnExit NoObject Events Count\n" + t.easyNoObjectEventsOnExit.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add NoObject Event OnExit"))
            {
                t.addNoObjectEventOnExit();
            }

            serializedObject.ApplyModifiedProperties();
            t.updateMultiplyEvents();
            t.updateNoObjectEvents();
        }
    }
#endif
}