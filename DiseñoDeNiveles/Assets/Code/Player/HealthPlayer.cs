using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public Image vidaBarImagen;
    public float vidaMax = 100f;
    public float vida = 100f;
    void Update()
    {
        vidaBarImagen.fillAmount = vida / vidaMax;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "damage")
        {

            vida -= other.GetComponent<DamageIntensity>().damageI;
        }
    }
}
