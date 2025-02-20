using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public LayerMask Wall;
    public float maxDistance = 10;
    [Header("Movimiento")]
    public GameObject[] points;
    public float moveSpeed = 1;
    public GameObject player;
    public Transform Pos1;
    public Transform Pos2;
    public float angulo = 90f;
    private float stopTimer = 0f;
    public float timeStopped = 1f;
    [Header("Enemy Range")]
    public Transform enemyPoint;
    public float enemyRang = 9f;
    public Collider[] detectedCollider;
    public bool isDetected = false;
    public LayerMask PlayerLayer;
    private NavMeshAgent agent;
    private Vector3 playerPosition;
    private Vector3 enemiePosition;
    public float distanceattack;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = timeStopped;
        agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindWithTag("Player");
        points = GameObject.FindGameObjectsWithTag("RandomPoint");
        FindRandomPoint();
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

            if (player != null)
            {
                //Debug.Log("Esta en el rango");
                Look();
                //transform.LookAt(player.transform);
                //transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            }
        }
        else
        {
            if (agent.remainingDistance <= 0.1 + agent.stoppingDistance)
            {
                stopTimer -= Time.deltaTime;
                if(stopTimer <= 0)
                {
                    Debug.Log("Nuevo destino");
                    FindRandomPoint();
                }
            }
        }

    }
    void Look()
    {
        Vector3 playerdirection = playerPosition - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerdirection.normalized, out hit, maxDistance, Wall))
        {
            // Si el rayo golpea algo, mostramos el nombre del objeto
            //Debug.Log("El rayo ha tocado: " + hit.collider.name);
            isDetected = false;

        }
        else
        {
            agent.SetDestination(player.transform.position);
            //Debug.Log("Esta en el rango");
        }
        Debug.DrawRay(transform.position, playerdirection.normalized);  
    }
    void FindRandomPoint()
    {
        //Calculamos un indice aleatorio dentro del rango del array
        int _randomIndex = Random.Range(0, points.Length);
        //Accedemos al elemento del array en el indice calculado, tenemos un punto aleatorio
        agent.SetDestination(points[_randomIndex].transform.position);
    }
    void EnemyCheck()
    {

        detectedCollider = Physics.OverlapSphere(enemyPoint.position, enemyRang, PlayerLayer);
        if (detectedCollider.Length > 0)
        {
            isDetected = true;
            
        }
        else
        {
            isDetected = false;
        }

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
