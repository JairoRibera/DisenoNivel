using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoMouse : MonoBehaviour
{
    public Button mibotom;

    void Update()
    {
        Cursor.visible = false;//Hacemos el raton invisible
        Cursor.lockState = CursorLockMode.Locked;//el raton se bloquea en medio de la pantalla(ideal para primera persona)
        if (Input.GetMouseButtonDown(0)) mibotom.Select();

    }
}
