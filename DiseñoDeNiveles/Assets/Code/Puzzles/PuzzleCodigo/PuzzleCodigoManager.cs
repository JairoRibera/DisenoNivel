using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PuzzleCodigoManager : MonoBehaviour
{
    public List<int> truelist = new List<int> { 1, 2, 3, 4 };
    public List<int> playlist = new List<int> { };
    public bool canPlayCode = false;
    //public Text textoLista;
    public bool iguales = false;
    public GameObject PanelCodigo;
    public GameObject Puerta;
    public Text TextoCo;
    public void AddNumber(int numero)
    {
        playlist.Add(numero);
        TextoCo.text += numero;
        if (playlist.Count == 4)
        {
            if (truelist.SequenceEqual(playlist))
            {
                PanelCodigo.SetActive(false);
                Puerta.SetActive(false);
                playlist.Clear();
            }
            else
            {
                Debug.Log("no");
                playlist.Clear();
                TextoCo.text = "";
            }
        }
    }
}
