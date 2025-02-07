using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerTimer : MonoBehaviour
{
    public RespawnPlayer RPreference;
    public bool haEmpezado = false;
    public GameObject Contador;
    public GameObject Tmuerte;
    public Text TextoContador;
    public Text TextoMuerte;
    private int contador = 10;  // Comenzamos en 10
    private float tiempo = 0.0f;
    public float intervalo = 1.0f; // Intervalo en segundos

    void Update()
    {
        Temporizador();
    }
    public void ManagerTimer1()
    {
        Temporizador();
        ActualizarTexto();
        
    }
    public void Temporizador()
    {
        if(haEmpezado == true)
        {
            tiempo += Time.deltaTime;
            //Iniciamos el contador
            if (tiempo >= intervalo && contador > 0)
            {
                contador--;
                tiempo = 0.0f;
                ActualizarTexto();
            }
            else if (contador <= 0)
            {
                //Desactivamos el contador y ponemos el texto de muerte
                Contador.SetActive(false);
                TextoDie();
                RPreference.RespawnthePlayer();
            }
        }
       
        
    }
    public void ActualizarTexto()
    {
       
        TextoContador.text = "Te faltan " + contador + " segundos";
    }
    public void TextoDie()
    {
        Tmuerte.SetActive(true);
        TextoMuerte.text = "Has muerto";
    }

}
