using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoMovimiento : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
