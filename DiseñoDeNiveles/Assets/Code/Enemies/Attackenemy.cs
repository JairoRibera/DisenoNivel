using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attackenemy : MonoBehaviour
{
    public bool Cerca = false;
    public GameObject hitBox;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    public void attack()
    {
        if(Cerca == true)
        {

            hitBox.SetActive(true);
            StartCoroutine(DeattackCo());
            Debug.Log("Muelto");
        }
        
    }
    private IEnumerator DeattackCo()
    {
        yield return new WaitForSeconds(1);
        hitBox.SetActive(false);
    }
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
