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
    public Controller CoReference;
    public bool panelactive = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Cerca == true)
        {
            PanelCodigo.SetActive(true);
            Panel.SetActive(false);
            CoReference.canMoveandRotate = false;
            panelactive = true;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && Cerca == true && panelactive == true)
        {
            PanelCodigo.SetActive(false);
            Panel.SetActive(true);
            CoReference.canMoveandRotate = true;
            panelactive = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CM.canPlayCode = true;
            Panel.SetActive(true);
            Cerca = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CM.canPlayCode = false;
            Panel.SetActive(false);
            Cerca = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
