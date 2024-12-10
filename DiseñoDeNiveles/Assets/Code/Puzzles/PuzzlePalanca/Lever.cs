using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator animPalanca;
    public Lever[] palancas = new Lever[4];
    public bool isActive;
    public bool canInteract;
    private LeverCodeManager _pCM;
    private void Start()
    {
        _pCM = FindAnyObjectByType<LeverCodeManager>();
        animPalanca = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            //isActive = true;
            //animPalanca.SetBool("LeverUp", true);
            if (isActive == true)
            {
                desactivar();
            }
            else
                activar();

        }

    }
    public void desactivar()
    {
        if (!isActive) return; //Evitar desactivar si ya esta desactivada
        isActive = false;
        animPalanca.SetBool("LeverUp", false);
        foreach (var palanca in palancas)
        {
            if (palanca != null && palanca.isActive)  // Solo desactivar palancas que están activas
            {
                palanca.desactivar();
            }
        }
    }
    public void activar()
    {
        if (isActive) return; // Evitar activar si ya está activa
        isActive = true;
        Debug.Log("mea ctivo " + gameObject);
        animPalanca.SetBool("LeverUp", true);
        foreach (var palanca in palancas)
        {
            if (palanca != null && !palanca.isActive)  // Solo activar palancas que no están activas
            {
                palanca.activar();
            }
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
