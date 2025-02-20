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
        if (Cerca == true)
        {
            hitBox.SetActive(true);
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                hitBox.SetActive(false);
            }
            Debug.Log("Muelto");
        }
        stopTimer++;
    }
    public void attack()
    {

    }
    //private IEnumerator DeattackCo()
    //{
    //    yield return new WaitForSeconds(5);
    //    hitBox.SetActive(false);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cerca = true;
            agent.isStopped = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cerca = false;
        }
    }
}
