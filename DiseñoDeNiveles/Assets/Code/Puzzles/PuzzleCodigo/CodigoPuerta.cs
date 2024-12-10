using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoPuerta : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PanelCodigo;
    public PuzzleCodigoManager CM;
    public bool Cerca;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Cerca == true)
        {
            PanelCodigo.SetActive(true);
            Panel.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CM.canPlayCode = true;
            Panel.SetActive(true);
            Cerca = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CM.canPlayCode = false;
            Panel.SetActive(false);
            Cerca = false;
        }
    }
}
