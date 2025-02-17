using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPuzzlePalanc : MonoBehaviour
{
    public bool canInteract = false;
    public List<Palanc> palancasReset;
    public GameObject puerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            foreach (var palancas in palancasReset)
            {
                palancas.Deactivate();
            }
            puerta.SetActive(true); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
