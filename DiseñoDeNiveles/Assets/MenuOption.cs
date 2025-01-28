using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MenuOption : MonoBehaviour
{
    public Slider sliderBrillo;
    public float sliderValue;
    public Image panelBrillo;
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resoluciones;
    public Slider sliderMusic;
    public float volume = 1f;
    private void Start()
    {
        volume = AudioListener.volume;

        // Si tienes un Slider, asignar el valor inicial
        if (sliderMusic != null)
        {
            sliderMusic.value = volume;
            sliderMusic.onValueChanged.AddListener(VolumeChange);
        }
        RevisarResolucion();
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
    }
    public void ChangeSliderBrillo(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
    }
    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> option = new List<string>();
        int resolucionActual = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            option.Add(opcion);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height) 
            {
                resolucionActual = i;
            }

        }
        resolutionDropDown.AddOptions(option);
        resolutionDropDown.value = resolucionActual;
        resolutionDropDown.RefreshShownValue();
        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
            
    }
    public void CambiarResolution(int indiceResolution)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolutionDropDown.value);
        Resolution resolucion = resoluciones[indiceResolution];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    public void VolumeChange(float newVolume)
    {
        volume = newVolume;
        AudioListener.volume = volume;
    }

}
