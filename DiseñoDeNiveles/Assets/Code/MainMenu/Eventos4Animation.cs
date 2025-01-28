using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos4Animation : MonoBehaviour
{
    public GameObject TituloUI;
    public GameObject MenuUI;
    public void ActivateTitulo()
    {
        TituloUI.SetActive(true);
    }    
    public void DesactivateTitulo()
    {
        TituloUI.SetActive(false);
    }    
    public void DesactivateObjects()
    {
        gameObject.SetActive(false);
    }
    public void ActivateObjects()
    {
        MenuUI.SetActive(true);
    }
}
