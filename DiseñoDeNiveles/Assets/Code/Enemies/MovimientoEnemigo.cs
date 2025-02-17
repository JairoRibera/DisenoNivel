using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    //Distintos puntos a los que puede moverse
    public GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Busca automaticamente todos los puntos usando el tag RandomPoint
        points = GameObject.FindGameObjectsWithTag("RandomPoint");
        FindRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //Solo persigue al jugador si lo ha detectado
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
        //Si no ha visto al jugador, se mueve libremente
        else
        {
            //Si esta lo suficientemente cerca de su destino, busco uno nuevo
            //Le añadimos un poco a su stoppingDistance para que funcione
            //Independientemente de  lo lejos o cerca que se pare
            if (agent.remainingDistance <= 0.1f + agent.stoppingDistance)
            {
                FindRandomPoint();
            }
        }

    }
    //Para cada vez que tenga que buscar un punto aleatorio
    void FindRandomPoint()
    {
        //Calculamos un indice aleatorio dentro del rango del array
        int _randomIndex = Random.Range(0, points.Length);
        //Accedemos al elemento del array en el indice calculado, tenemos un punto aleatorio
        agent.SetDestination(points[_randomIndex].transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Si el que entra en el trigger es el jugador, lo vamos a perseguir
        if (other.CompareTag("Player") == true)
        {
            player = other.transform;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //Si lo que abandona el trigger es el jugador, dejamos de perseguirlo
        //Tambien tiene que comprobar que es el jugador este a la variable player
        if (player != null && player == other.transform)
        {
            //Volvemos a poner la variable en null para que deje de perseguir al jugador
            player = null;
        }
    }
}
