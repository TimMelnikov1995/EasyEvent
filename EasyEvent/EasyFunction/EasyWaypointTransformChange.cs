using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyWaypointTransformChange : MonoBehaviour
{
    public Transform target;
    public Transform allWaypointsParent;
    public MeshRenderer[] waypoints;
    public bool random;
    int currentWaypoint;

    void Start()
    {
        if (!target)
        {
            target = transform;
        }
        waypoints = allWaypointsParent.GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        
    }

    public void NextWaypoint()
    {
        if (!random)
        {
            NextCurrentWaypointCounter();
            target.position = waypoints[currentWaypoint].transform.position;
        }
        else
        {
            RandomCurrentWaypointCounter();
            target.position = waypoints[currentWaypoint].transform.position;
        }
    }

    void NextCurrentWaypointCounter()
    {
        currentWaypoint += 1;
        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
    void RandomCurrentWaypointCounter()
    {
        currentWaypoint = Random.Range(0, waypoints.Length - 1);
    }
}