using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject PanelGameOver;
    public GameObject posInitial;
    public GameObject Player;
    //public HealthPlayer HPReference;
    public ShowGameOver SHOreference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RespawnthePlayer();
    }
    //public void RespawnthePlayer()
    //{
    //    if(HPReference.vida <= 0)
    //    {
    //        HPReference.isdeath = true;
    //        SHOreference.Showanim();
    //        StartCoroutine(RespawnPlayerCO());
    //    }

    //}
    //public IEnumerator RespawnPlayerCO()
    //{
    //    yield return new WaitForSeconds(3);
    //    Player.transform.position = posInitial.transform.position;
    //    HPReference.vida = HPReference.vidaMax;
    //    SHOreference.anim.SetBool("Respawn", true);
    //    SHOreference.anim.SetBool("isDeath", false);
    //    HPReference.isdeath = false;
    //    yield return new WaitForSeconds(1);
    //    SHOreference.anim.SetBool("Respawn", false);

    //}
}
