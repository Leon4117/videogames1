using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Weather : MonoBehaviour
{
    //Porque son componentes material
    public Material cloudy;
    public Material sunny;
    public Material night;
    //cambiar el sky box

    //modificar luces 
    public Light mainLight;
    public Light secLight;
    public Light terLight;

    public Color cloudyLi = new Color(0.5f, 0.5f, 0.6f);
    public Color sunnyLi = Color.white;
    public Color nightLi = new Color(0.2f, 0.2f, 0.3f);
    //luces del carro
    public Light[] carroLuces;
    public Light[] farosLuces;
    //luces de la calle
    public Light[] calleLuces;

    public void Start()
    {
        //asignar las luces de los faros
        GameObject[] calleLucesObject = GameObject.FindGameObjectsWithTag("FaroLuz");
        calleLuces = new Light[calleLucesObject.Length];
        for (int i = 0;i < calleLucesObject.Length; i++)
        {
            calleLuces[i] = calleLucesObject[i].GetComponent<Light>();
        }
    }
    public void ChangeSkybox(int weatherType)
    {
        switch (weatherType)
        {
            case 1:
                //se asigna el material al skybox
                Debug.Log("Nublado");
                PrenderLuces(false);
                //asigna cierta intensidad a las luces junto con el color
                mainLight.intensity = 0.8f;
                mainLight.color = cloudyLi;
                if (secLight != null) secLight.intensity = 0.3f;
                LucesCarro(1.0f, false);
                RenderSettings.skybox = cloudy;

                break;
            case 2:
                Debug.Log("Soleado");
                PrenderLuces(false);
                mainLight.intensity = 0.9f;
                mainLight.color = sunnyLi;
                if (secLight != null) secLight.intensity = 0.9f;
                if (terLight != null) terLight.intensity = 0.3f;
                LucesCarro(0.7f, false);
                RenderSettings.skybox = sunny;

                break;
            case 3:
                Debug.Log("Noshe");
                PrenderLuces(true);
                mainLight.intensity = 0.5f;
                mainLight.color = nightLi;
                if (secLight != null) secLight.intensity = 0.3f;
                terLight.intensity = 0.2f;
                LucesCarro(1.5f,true);
                
                RenderSettings.skybox = night;
                break;
            default:
                Debug.Log("No existe");
                break;

        }
        //Actualizar el clima
        DynamicGI.UpdateEnvironment();
    }
    public void LucesCarro(float intensidad)
    {
        foreach (var light in carroLuces) { 
            light.intensity = intensidad;
        }
    }
    public void LucesCarro(float intensidad, bool faros)
    {
        foreach (var light in carroLuces)
        {
            light.intensity = intensidad;
        }
        foreach (var light in farosLuces)
        {
            light.enabled = faros;
        }
    }
    public void PrenderLuces(bool estado)
    {
        foreach (var light in calleLuces)
        {
            light.enabled = estado;
        }
    }

}