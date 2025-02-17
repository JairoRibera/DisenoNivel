using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isactive = false;
    public float maxDistance;
    public LayerMask Puzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            interactObject();
        }
    }
    public void interactObject() 
    {
        Ray _ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
        if (Physics.Raycast(_ray, out RaycastHit _hit, maxDistance, Puzzle))
        {
                Debug.Log("botom" + _hit.collider.name);
        }
        else
        {
            Debug.Log("no oñasghña");
        }
        Debug.DrawRay(_ray.origin, _ray.direction * maxDistance);
    }
}
