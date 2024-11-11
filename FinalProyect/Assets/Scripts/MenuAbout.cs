using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MenuAbout : MonoBehaviour
{
    //del que creamos
    [SerializeField] private AudioMixer audioMixer;
    //controlar pantalla completa
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
   
    public void Volumen(float volumen)
    {
        audioMixer.SetFloat("Volumen",volumen);
    }
    //setting->quality
    public void Calidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
