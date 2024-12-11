using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanc : MonoBehaviour
{
    public bool canActivate = false;
    public GameObject pirulo;
    public bool active = false;
    public Palanc[] palancs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate)
        {
            Debug.Log("Que passa " + gameObject.name, gameObject);
            if(active == true)
            {
                Deactivate();
                foreach (Palanc pal in palancs)
                {
                    pal.Deactivate();
                }
            }
            else
            {
                Activate();
                foreach (Palanc pal in palancs)
                {
                    pal.Activate();
                }
            }

        }
    }

    public void Activate()
    {
        active = true;
        pirulo.SetActive(false);
    }

    public void Deactivate()
    {
        active = false;
        pirulo.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = false;
        }
    }
}
