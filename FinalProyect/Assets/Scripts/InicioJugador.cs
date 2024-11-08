using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int indexCarro = PlayerPrefs.GetInt("SeleccionIndex");
        Quaternion rotacion = Quaternion.Euler(0, 90, 0);
        //Vector3 posicion = new Vector3(105, 70, 10);
        Instantiate(GameManager.Instance.seleccionsCar[indexCarro].carroPosible, transform.position, rotacion);
    }

    
}
