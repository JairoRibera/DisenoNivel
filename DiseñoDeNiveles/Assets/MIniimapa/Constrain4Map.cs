using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constrain4Map : MonoBehaviour
{
    //este scipt lo usaremos en un objeto del minimapa que deba seguir a un objeto en la vida real
    public Transform target;//este es el objeto de la vida real al que debe seguir
    public Transform map_obj;//este es el mapa que está debajo del escenario (gracias a él sabemos a que altura debo ponerme)
    public bool positionConstrain = true;
    public bool rotationContrain = true;
    public float offsetY = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (positionConstrain == true)
        {
            transform.position = new Vector3(target.position.x, map_obj.position.y + offsetY, target.position.z);
        }
        if (rotationContrain == true)
        {
            transform.rotation = target.rotation;
        }



    }
}

