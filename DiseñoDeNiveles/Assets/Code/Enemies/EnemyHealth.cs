using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int vida = 10;
    public int vidaMax = 10;

    private void Start()
    {
        vida = vidaMax;
    }
    public void TakeDamage(int _damage)
    {
        vida -= _damage;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
