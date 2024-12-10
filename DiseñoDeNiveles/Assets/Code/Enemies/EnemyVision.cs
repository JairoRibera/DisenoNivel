using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public float moveSpeed = 1;
    private GameObject player;
    public Transform Pos1;
    public Transform Pos2;
    public float angulo = 90f;
    [Header("Enemy Range")]
    public Transform enemyPoint;
    public float enemyRang = 9f;
    public Collider[] detectedCollider;
    public bool isDetected = false;
    public LayerMask PlayerLayer;
    private NavMeshAgent agent;
    private Vector3 playerPosition;
    private Vector3 enemiePosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        enemiePosition = transform.position;

        EnemyCheck();
        //calculamos la direccion donde esta el jugador
        Vector3 playerdirection = player.transform.position - transform.position;
        //calculamos el angulo donde mira el enemigo y la direccion del enemigo
        float angle = Vector3.Angle(transform.forward, playerdirection);
        //si el angulo donde mira el enemigo es menor al angulo de de la variable float y el bool es true, entonces el enemigo se dirige a donde esta el juegador
        if (angle <= angulo * .5f && isDetected == true)
        {
            Debug.Log("Esta en el rango");
            agent.SetDestination(player.transform.position);
            //transform.LookAt(player.transform);
            //transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No te veo");
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
        Gizmos.DrawLine(enemiePosition, playerPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, Pos1.transform.position);
        Gizmos.DrawLine(transform.position, Pos2.transform.position);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyPoint.position, enemyRang);
    }

}
