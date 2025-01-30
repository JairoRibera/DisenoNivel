using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargarBala : MonoBehaviour
{
    public UIcontroller _uIReference;
    public ShootFP shoot;
    private void Start()
    {
        //Inicializamos la referencia al LevelManager
        //_lMReference = GameObject.Find("LevelManager").GetComponent<LeverManager>();
        //Inicializamos la referencia al UIController
        //_uIReference = GameObject.Find("Canvas").GetComponent<UIcontroller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shoot.bullet = 10;
            _uIReference.UpdateGemCount();
            shoot.havebullet = true;
            Destroy(gameObject);

        }
    }
}
