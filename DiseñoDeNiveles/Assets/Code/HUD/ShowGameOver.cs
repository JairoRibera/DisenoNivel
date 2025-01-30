using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOver : MonoBehaviour
{
    public Animator anim;
    public HealthPlayer health;
    public GameObject PanelGameOver;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Showanim();
    }
    public void Showanim()
    {
        if (health.isdeath == true)
        {
            PanelGameOver.SetActive(true);
            anim.SetBool("isDeath", true);
        }
    }
}
