using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuSeleccion : MonoBehaviour
{
    private int index;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nombre;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
        index = PlayerPrefs.GetInt("SeleccionIndex");
        if(index > gameManager.seleccionsCar.Count-1)
        {
            index = 0;
        }
        CambiarSeleccion();
    }

    public void CambiarSeleccion()
    {
        PlayerPrefs.SetInt("SeleccionIndex", index);
        image.sprite = gameManager.seleccionsCar[index].imagen;
        nombre.text = gameManager.seleccionsCar[index].nombre;
    }
    public void SigCarro()
    {
        if (index == gameManager.seleccionsCar.Count - 1)
        {   
            index =0;
        }else
        {
            index += 1;
        }
        CambiarSeleccion();
    }

    public void AntCarro()
    {
        if (index == 0)
        {
            index = gameManager.seleccionsCar.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarSeleccion();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
