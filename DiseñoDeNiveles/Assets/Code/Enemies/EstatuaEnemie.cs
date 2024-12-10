using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstatuaEnemie : MonoBehaviour
{
    private Controller PlayerCo;
    private NavMeshAgent agent;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        PlayerCo = player.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCo.isLooking == false)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
            //transform.position = Vector3.MoveTowards(transform.position, PPos.position, speed * Time.deltaTime);

        }
        else
        {
            agent.isStopped = true;
        }
    }
}
