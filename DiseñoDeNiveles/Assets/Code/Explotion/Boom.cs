using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float timeToExplote = 1f;
    public float explotionRange = 3f;
    //Las layers que puede detectar el Overlap
    public LayerMask affectedLayers;
    //Para guardar los objetos que detecta el Overlap
    public Collider[] targets;
    void Start()
    {
        //En cuanto se crea o se activa este objeto, inicia la explosion
        StartCoroutine(CRT_Explote());
    }

    IEnumerator CRT_Explote()
    {
        yield return new WaitForSeconds(timeToExplote);
        Debug.Log("jlñasdghñasg");
        //En el momento de la explosion, crea el overlap para detectar todos los objetos afectados
        targets = Physics.OverlapSphere(transform.position, explotionRange, affectedLayers);
        foreach (Collider target in targets)
        {
            //Si encuentra a un enemigo le hace daño pero no lo destruye
            if(target.CompareTag("Enemy") == true)
            {
                Debug.Log("Muere, filibustero dasghasg");
                //Accede al componente EnemyHealth del enemigo y le hace daño
                target.GetComponent<EnemyHealth>().TakeDamage(5);
            }
            else
            {
                Destroy(target.gameObject);
            }
        }
        //Una vez ha explotado, se autodestruye
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotionRange);
    }
}
