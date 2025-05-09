using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{
    public GameObject panel1, panel2, panel3;
    public ColorArea[] areas;
    public GameObject peluche;
    public GameObject enemy;
    public Animator enemyAnim;
    public Animator anim;
    void Update()
    {
        //para contar cuantas areas estan correctas
        int _correctAreas = 0;
        foreach (ColorArea area in areas)
        {
            //cada vez que encuentre un area correcta, suma 1 al contador de areas
            if (area.isCorrect == true)
            {
                _correctAreas++;
            }
        }
        //comprobar si hay tantas areas correctas como elementos dentro del array de areaas
        if (_correctAreas == areas.Length)
        {
            //si se cumple, se ha completado el puzzle correctamente :)
            //obstacle.SetActive(false);
            peluche.SetActive(true);
            Destroy(panel1);
            Destroy(panel2);
            Destroy(panel3);
            enemy.SetActive(true);
            
            anim.SetBool("IsComplete", true);
        }
    }
}
