using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    //Porque son componentes material
    public Material cloudy;
    public Material sunny;
    public Material night;
    //cambiar el sky box
    public void ChangeSkybox(int weatherType)
    {
        switch (weatherType)
        {
            case 1:
                //se asigna el material al skybox
                Debug.Log("Nublado");
                RenderSettings.skybox = cloudy;
                break;
            case 2:
                Debug.Log("Soleado");
                RenderSettings.skybox = sunny;
                break;
            case 3:
                Debug.Log("Noshe");
                RenderSettings.skybox = night;
                break;
            default:
                Debug.Log("No existe");
                break;

        }
        //Actualizar el clima
        DynamicGI.UpdateEnvironment();
    }
}