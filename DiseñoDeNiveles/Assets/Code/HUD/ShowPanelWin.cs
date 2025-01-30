using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelWin : MonoBehaviour
{
    public GameObject panelWin;
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelWin.SetActive(true);
            anim.SetBool("isWin", true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
