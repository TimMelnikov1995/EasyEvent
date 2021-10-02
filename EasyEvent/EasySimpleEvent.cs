using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public enum EventCallMethod // создаем выбор метода при помощи которого будем вызывать событие
{
    OnStart, 
    OnEnable,
    OnFixedUpdate,  
    ByTimer, // по таймеру (время задается в инспекторе)
    OnDestroy,
    OnDisable,
    OnCall
}

public class EasySimpleEvent : MonoBehaviour
{
    [Tooltip("Выбор когда вызывать событие")]
    public EventCallMethod eventCallMethod;
    [Tooltip("Время через которое будет вызываться событие. \n !!!Требуется выставить параметр eventCallMethod в значение ByTimer!!!")]
    public float EventCallTimer = 1;

    public List<EasyMultiplyParamEvent> easyMultiplyParamEvents = new List<EasyMultiplyParamEvent>(0);

    public UnityEvent Event;

    void Start()
    {
        if (eventCallMethod == EventCallMethod.OnStart)
        {
            callEvent();
        }

        if (eventCallMethod == EventCallMethod.ByTimer)
        {
            StartCoroutine(byTimer());
        }

        if (eventCallMethod == EventCallMethod.OnFixedUpdate)
        {
            StartCoroutine(onFixedUpdate());
        }
    }

    private void OnEnable()
    {
        if (eventCallMethod == EventCallMethod.OnEnable)
        {
            callEvent();
        }
        if (eventCallMethod == EventCallMethod.OnStart)
        {
            callEvent();
        }

        if (eventCallMethod == EventCallMethod.ByTimer)
        {
            StartCoroutine(byTimer());
        }

        if (eventCallMethod == EventCallMethod.OnFixedUpdate)
        {
            StartCoroutine(onFixedUpdate());
        }
    }

    IEnumerator byTimer()
    {
        callEvent();
        yield return new WaitForSeconds(EventCallTimer);
        StartCoroutine(byTimer());
    }

    IEnumerator onFixedUpdate()
    {
        callEvent();
        yield return new WaitForFixedUpdate();
        StartCoroutine(onFixedUpdate());
    }

    private void OnDisable()
    {
        if(eventCallMethod == EventCallMethod.OnDisable)
        {
            callEvent();
        }
    }

    private void OnDestroy()
    {
        if (eventCallMethod == EventCallMethod.OnDestroy)
        {
            callEvent();
        }
    }

    void addMultiplyEvent()
    {
        EasyMultiplyParamEvent newEvent = new GameObject("MultyplayParamEvent").AddComponent<EasyMultiplyParamEvent>();
        newEvent.transform.parent = transform;
        easyMultiplyParamEvents.Add(newEvent);

    }
    void updateMultiplyEvents()
    {
        for (int i = 0; i < easyMultiplyParamEvents.Count; i++)
        {
            if (!easyMultiplyParamEvents[i])
            {
                easyMultiplyParamEvents.RemoveAt(i);
            }
        }
    }

        public void callEvent()
    {
        Event.Invoke();
        if (easyMultiplyParamEvents.Count > 0)
        {
            for (int i = 0; i < easyMultiplyParamEvents.Count; i++)
            {
                easyMultiplyParamEvents[i]._Invoke();
            }
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(EasySimpleEvent))]
    [CanEditMultipleObjects]
    class EasySimpleEventEditor : Editor
    {
        SerializedProperty Event;
        SerializedProperty eventCallMethod;
        SerializedProperty EventCallTimer;

        private void OnEnable()
        {
            Event = serializedObject.FindProperty("Event");
            eventCallMethod = serializedObject.FindProperty("eventCallMethod");
            EventCallTimer = serializedObject.FindProperty("EventCallTimer");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var t = (target as EasySimpleEvent);

            EditorGUILayout.PropertyField(eventCallMethod);
            EditorGUILayout.PropertyField(EventCallTimer);
            EditorGUILayout.PropertyField(Event);
            if (t.easyMultiplyParamEvents != null)
            {
                if (t.easyMultiplyParamEvents.Count > 0)
                {
                    EditorGUILayout.HelpBox("Multiply Parametr Events Count\n" + t.easyMultiplyParamEvents.Count.ToString(), MessageType.Info);
                }
            }
            if (GUILayout.Button("Add Myltiply Parametr Event"))
            {
                t.addMultiplyEvent();
            }

            serializedObject.ApplyModifiedProperties();
            t.updateMultiplyEvents();
        }
    }
#endif
}