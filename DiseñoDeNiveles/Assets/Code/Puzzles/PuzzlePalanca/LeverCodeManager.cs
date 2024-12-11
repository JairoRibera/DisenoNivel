using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCodeManager : MonoBehaviour
{
    public GameObject puerta;
    public Palanc[] palancas = new Palanc[4];
    private Palanc lever;
    public bool estanactivas = false;
    // Start is called before the first frame update
    void Start()
    {
        lever = GameObject.FindWithTag("Lever").GetComponent<Palanc>();
    }

    // Update is called once per frame
    void Update()
    {
        TodasLasPalancasActivas();
    }
    // Verifica si todas las palancas están activadas
    private void TodasLasPalancasActivas()
    {
        int _correctPalanca = 0;
        foreach (var palanca in palancas)
        {
            if (palanca.active == true)  // Si alguna palanca no está activa
            {
                //return false;  // No todas las palancas están activas
                _correctPalanca++;
            }

        }
        //return true;  // Todas las palancas están activas
        if (_correctPalanca == palancas.Length)
        {
            //si se cumple, se ha completado el puzzle correctamente :)
            puerta.SetActive(false);
        }
    }
    public void DesactivarPalancas()
    {
        foreach (var palanca in palancas)
        {
            palanca.Deactivate();

        }
    }
}
