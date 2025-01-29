using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public bool isdeath = false;
    public Image vidaBarImagen;
    public float vidaMax = 100f;
    public float vida = 100f;
    void Update()
    {
        vidaBarImagen.fillAmount = vida / vidaMax;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            vida = 0;
        }
        ComprobarVida();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "damage")
        {

            vida -= other.GetComponent<DamageIntensity>().damageI;
        }
    }
    public void ComprobarVida()
    {
        if (vida <= 0)
        {
            isdeath = true;
        }
        else
            isdeath = false;
    }
}
