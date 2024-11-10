using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // index jugador
        int indexCarro = PlayerPrefs.GetInt("SeleccionIndex");
        //la rotación en la que lo quiero
        Quaternion rotacion = Quaternion.Euler(0, 90, 0);
        //Vector3 posicion = new Vector3(105, 70, 10);
        //intanciar el personaje, esta en game manager lista  le damos el index tomamos al prefab
        Instantiate(GameManager.Instance.seleccionsCar[indexCarro].carroPosible, transform.position, rotacion);
    }

    
}
