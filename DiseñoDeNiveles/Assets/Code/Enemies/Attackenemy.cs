using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attackenemy : MonoBehaviour
{
    public bool Cerca = false;
    public GameObject hitBox;
    private NavMeshAgent agent;
    public float stopTimer = 0f;
    public float timeStopped = 1f;
    public bool canattack = false;
    public float attackCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = timeStopped;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();

    }
    void attack()
    {
        if (Cerca == true && canattack == true)
        {

            hitBox.SetActive(true);
            attackCounter = attackCounter - 1;
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                Debug.Log("añlsdgjasñlgjas´dghasdh");
                hitBox.SetActive(false);
            }
            //stopTimer = timeStopped;
            //StartCoroutine(DeattackCo());
            //Debug.Log("Muelto");
            //canattack = false;
        }
    }
    //private IEnumerator DeattackCo()
    //{
    //    yield return new WaitForSeconds(1);
    //    hitBox.SetActive(false);
    //    canattack = false;
    //    Debug.Log("doñlagjds");
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canattack = true;
            Cerca = true;
            agent.isStopped = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cerca = false;
            canattack = false;

        }
    }
}
