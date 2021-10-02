using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class EasyTimerEvent : MonoBehaviour
{
    public float time = 0.5f;
    float timeRun;
    public bool random;
    public bool loop;
    public Vector2 minMaxTime;
    public UnityEvent OnExitTime;

    public List<EasyMultiplyParamEvent> easyMultiplyParamEvents = new List<EasyMultiplyParamEvent>(0);

    void Start()
    {
        if (!random)
        {
            timeRun = time;
        }
        else
        {
            timeRun = Random.Range(minMaxTime.x, minMaxTime.y);
        }
    }
    void Update()
    {
        timeRun -= Time.deltaTime;
        if (timeRun <= 0)
        {
            OnExitTime.Invoke();
            if (easyMultiplyParamEvents.Count > 0)
            {
                for (int i = 0; i < easyMultiplyParamEvents.Count; i++)
                {
                    easyMultiplyParamEvents[i]._Invoke();
                }
            }
            if (!random)
            {
                timeRun = time;
            }
            else
            {
                timeRun = Random.Range(minMaxTime.x, minMaxTime.y);
            }

            if (!loop)
            {
                gameObject.SetActive(false);
            }
            else
            {
                restartTimer();
            }
        }
    }
    public void restartTimer()
    {
        if (!random)
        {
            timeRun = time;
        }
        else
        {
            timeRun = Random.Range(minMaxTime.x, minMaxTime.y);
        }
        if (!loop)
        {
            gameObject.SetActive(false);
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
        OnExitTime.Invoke();
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EasyTimerEvent))]
    [CanEditMultipleObjects]
    class EasyTimerEventEditor : Editor
    {
        SerializedProperty time;
        SerializedProperty random;
        SerializedProperty loop;
        SerializedProperty minMaxTime;
        SerializedProperty OnExitTime;

        private void OnEnable()
        {
            time = serializedObject.FindProperty("time");
            random = serializedObject.FindProperty("random");
            loop = serializedObject.FindProperty("loop");
            minMaxTime = serializedObject.FindProperty("minMaxTime");
            OnExitTime = serializedObject.FindProperty("OnExitTime");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var t = (target as EasyTimerEvent);

            EditorGUILayout.PropertyField(time);
            EditorGUILayout.PropertyField(loop);
            EditorGUILayout.PropertyField(random);
            if (random.boolValue)
            {
                EditorGUILayout.PropertyField(minMaxTime);
            }
            EditorGUILayout.PropertyField(OnExitTime);
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