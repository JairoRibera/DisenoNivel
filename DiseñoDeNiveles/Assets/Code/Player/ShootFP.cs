using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFP : MonoBehaviour
{
    public float shootRange;
    public float fireRate = 10f;
    private float shootTimer = 0f;
    public bool havebullet;
    public float bullet = 10;
    void Start()
    {
        bullet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarBala();
        Shoot();
    }
    public void ComprobarBala()
    {
        if(bullet <= 0)
        {
            havebullet = false;
        }
        else
        {
            havebullet = true;
        }
    }
    public void Shoot()
    {
        if (Input.GetMouseButton(0) && shootTimer <= 0f && havebullet == true)
        {
            Ray _ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
            if (Physics.Raycast(_ray, out RaycastHit _hit, shootRange))
            {
                Debug.Log("He disparado a" + _hit.collider);
                bullet--;
                if (_hit.collider.CompareTag("Enemy"))
                {
                    _hit.collider.GetComponent<EnemyHealth>().TakeDamage(1);
                }
            }
            Debug.DrawRay(_ray.origin, _ray.direction * shootRange);
            shootTimer = 1f / fireRate;
        }

        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }
}
