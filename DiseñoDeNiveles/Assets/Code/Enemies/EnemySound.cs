using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySound : MonoBehaviour
{
    public float moveSpeed = 3f;
    private GameObject player;
    public float detectionRadius = 20f; // Radio de detección
    public LayerMask playerLayer; // Capa del jugador
    private PlayerController pC;
    private Vector3 lastPosPlayer;
    private NavMeshAgent agent;
    private void Start()
    {
        pC = FindAnyObjectByType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        // Verifica si hay sonidos en el área de detección
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        foreach (var hitCollider in hitColliders)
        {
            // Lógica para reaccionar al sonido
            ReactToSound(hitCollider);
        }
        lastPosPlayer = player.transform.position;
    }
    public Vector3 GetLastPosition()
    {
        return lastPosPlayer;
    }
    public void ReactToSound(Collider player)
    {

        if (pC.doSound == true)
        {
            //Debug.Log("¡Sonido detectado de: " + player.name + "!");
            // Implementa la lógica para mover al enemigo hacia el jugador
            // Por ejemplo, hacer que se mueva hacia el jugador
            //transform.LookAt(player.transform);
            // Aquí puedes agregar movimiento hacia el jugador o cambiar el estado
            //transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(player.transform.position);
        }
        //else
        //    transform.position = Vector3.MoveTowards(transform.position, lastPosPlayer, moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        // Para visualizar el área de detección en el editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;

    }
}
