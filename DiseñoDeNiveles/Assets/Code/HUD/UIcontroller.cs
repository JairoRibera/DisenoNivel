using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder trabajar con elementos de la UI
using TMPro;
public class UIcontroller : MonoBehaviour
{
    //Referencia al texto de las gemas de la UI
    public TextMeshProUGUI gemText;
    public ShootFP shootRef;
    private void Start()
    {

        //_lMReference = GameObject.Find("LevelManager").GetComponent<LeverManager>();
    }
    public void UpdateGemCount()
    {
        //Actualizar el número de gemas recogidas
        //Cast -> convertimos el número entero en texto para que pueda ser representado en la UI
        gemText.text = shootRef.bullet.ToString();

    }
}
