using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargarBala : MonoBehaviour
{
    public ShootFP shoot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shoot.havebullet = true;
            shoot.bullet = 10;
            Destroy(gameObject);

        }
    }
}
