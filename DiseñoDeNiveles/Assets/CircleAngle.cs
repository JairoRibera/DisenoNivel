using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAngle : MonoBehaviour
{
    public float distancia = 5f; // Distancia de detecci�n
    public float angulo = 45f; // �ngulo en grados

    void Update()
    {
        DetectarObjetosEnCono();
    }

    void DetectarObjetosEnCono()
    {
        Collider[] objetos = Physics.OverlapSphere(transform.position, distancia);
        foreach (var obj in objetos)
        {
            Vector3 direccion = (obj.transform.position - transform.position).normalized;

            // Comprueba el �ngulo
            if (Vector3.Angle(transform.forward, direccion) < angulo / 2)
            {
                Debug.Log("Objeto detectado: " + obj.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Dibuja el �rea de detecci�n en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distancia);

        // Dibuja l�neas para representar el cono
        Vector3 rightDirection = Quaternion.Euler(0, angulo / 2, 0) * transform.forward * distancia;
        Vector3 leftDirection = Quaternion.Euler(0, -angulo / 2, 0) * transform.forward * distancia;

        Gizmos.DrawLine(transform.position, transform.position + rightDirection);
        Gizmos.DrawLine(transform.position, transform.position + leftDirection);
    }
}