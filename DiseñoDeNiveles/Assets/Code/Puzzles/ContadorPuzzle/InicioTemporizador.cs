using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioTemporizador : MonoBehaviour
{
    public GameObject Contador;
    public ManagerTimer managerTimer;

    private void Start()
    {
        managerTimer.GetComponent<ManagerTimer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            managerTimer.haEmpezado = true;
            Debug.Log("Detectado");
            Contador.SetActive(true);
            managerTimer.Temporizador();
        }
    }
}
