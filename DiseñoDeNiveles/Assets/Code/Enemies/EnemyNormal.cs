using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNormal : MonoBehaviour
{
    public float moveSpeed = 1f;
    private GameObject player;
    [Header("Enemy Range")]
    public Transform enemyPoint;
    public float enemyRang = 9f;
    public Collider[] detectedCollider;
    public LayerMask PlayerLayer;
    public bool isDetected = false;
    private NavMeshAgent agent;
    //Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    //// Update is called once per frame
    void Update()
    {
        EnemyCheck();
        EnemyPersecution();
    }
    void EnemyPersecution()
    {
        //Si esta detectando al jugador, se mueve hacia su posicion
        if (isDetected == true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(player.transform.position);
        }
    }
    void EnemyCheck()
    {

        detectedCollider = Physics.OverlapSphere(enemyPoint.position, enemyRang, PlayerLayer);
        if (detectedCollider.Length > 0)
        {
            isDetected = true;
        }
        else
            isDetected = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyPoint.position, enemyRang);
    }
}
