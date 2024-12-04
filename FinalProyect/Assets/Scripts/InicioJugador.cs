using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    private Weather weather;
    private Musica musica;
    [SerializeField] private SpawnManager spawnManagerScript;

    void Start()
    {
        // index jugador
        int indexCarro = PlayerPrefs.GetInt("SeleccionIndex");
        //la rotación en la que lo quiero
        Quaternion rotacion = Quaternion.Euler(0, 90, 0);
        //la posicion que toma es la del objeto InicioJugador
        //intanciar el personaje, esta en game manager lista  le damos el index tomamos al prefab
        Instantiate(GameManager.Instance.seleccionsCar[indexCarro].carroPosible, transform.position, rotacion);
        //nuevo clima
        //encontrar untania de un objeto, en este caso srcip
        weather = FindObjectOfType<Weather>();
        weather.ChangeSkybox(TypeSky());
        //para reprodur la musica
        Musica.Instance.audioSource.Stop();
        Musica.Instance.ElegirMusic();

        spawnManagerScript = GameObject.FindObjectOfType<SpawnManager>();
        if (spawnManagerScript != null)
        {
            Debug.Log("SpawnManager encontrado. Configurando obstáculos.");
            spawnManagerScript.InvokeRepeating("SpawnObstacles", 2.0f, 2.0f);
        }
        else
        {
            Debug.LogError("SpawnManager no encontrado.");
        }
    }

    private int TypeSky()
    {
        int tipoCielo = 0 ;
        return tipoCielo = Random.Range(1,4);
    }

    
}
