using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
    //estos puntos se los deben pasar del "Player"
    private float puntos;
    [SerializeField] private TextMeshProUGUI puntaje1;
    [SerializeField] private TextMeshProUGUI puntaje2;
    [SerializeField] private TextMeshProUGUI puntaje3;
    [SerializeField] private TextMeshProUGUI puntajeTotal;
    //Contenedores informacion
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPuntaje;
    public bool gameEnd = false;
    private void Start()
    {
        
    }


    private void Update()
    {
        //segundos
        puntos += Time.deltaTime; 
        //modificar el text ,solo enteros
        puntaje1.text = "100000"; 
        puntaje2.text = "165400"; 
        puntaje3.text = "000000"; 
        puntajeTotal.text = "1234567";
    }

    //posibles metodos para agregar los puntos
    public void SumarPuntos(float puntosTotales)
    {
        puntos += puntosTotales;
    }
    //para activar el panel de los puntos
    public void MostrarPuntajeFinal()
    {
        puntaje1.text = puntos.ToString("0");
        buttonPause.SetActive(false);
        menuPuntaje.SetActive(true);
    }
}
