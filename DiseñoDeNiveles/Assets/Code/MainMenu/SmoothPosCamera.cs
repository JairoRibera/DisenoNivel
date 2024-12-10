using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPosCamera : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);
    }
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
