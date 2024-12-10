using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStatue : MonoBehaviour
{
    public Transform PPos;
    public Transform pPos;
    public PlayerController Player;
    public float speed;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = agent.acceleration;
        if (Player.isLooking == false)
        {
            agent.isStopped = false;
            agent.SetDestination(pPos.position);
            //transform.position = Vector3.MoveTowards(transform.position, PPos.position, speed * Time.deltaTime);

        }
        else if (Player.isLooking == true)
        {
            agent.isStopped = true;
        }
    }
}
