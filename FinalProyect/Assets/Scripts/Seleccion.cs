using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NuevoCarro", menuName="TipoCarro")]
public class Seleccion : ScriptableObject
{
    //contenedores informacion
    public GameObject carroPosible;

    public Sprite imagen;
    public string nombre;
}
