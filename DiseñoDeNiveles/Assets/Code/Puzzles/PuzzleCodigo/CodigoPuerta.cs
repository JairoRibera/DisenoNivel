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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Cerca == true)
        {
            PanelCodigo.SetActive(true);
            Panel.SetActive(false);
            CoReference.canMoveandRotate = false;
        }
        if(Input.GetKeyDown(KeyCode.F) && Cerca == true)
        {
            PanelCodigo.SetActive(false);
            Panel.SetActive(true);
            CoReference.canMoveandRotate = true;
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
