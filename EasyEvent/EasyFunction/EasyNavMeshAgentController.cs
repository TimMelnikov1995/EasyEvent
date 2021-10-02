using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EasyNavMeshAgentController : MonoBehaviour
{
    public Transform destinationPoint;
    NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }
    public void updateDestinationPoint()
    {
        if (destinationPoint)
        {
            _agent.SetDestination(destinationPoint.position);
        }
    }
}