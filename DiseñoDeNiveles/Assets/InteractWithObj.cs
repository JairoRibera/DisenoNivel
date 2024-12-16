using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObj : MonoBehaviour
{
    public float maxDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check();
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue);
    }
    public void Check()
    {
        Ray rayo = new Ray(transform.position, transform.forward);
        bool detectado = Physics.Raycast(rayo, out RaycastHit hit, maxDistance);
        if (!detectado) return;
        switch (hit.collider.tag)
        {
            case "Puerta":
                //hit.collider.GetComponent<Puerta>().Abrir;
                break;
            case "Buttom":

                break;
            case "Object":

                break;
            case "Key":

                break;
        }

    }
}
