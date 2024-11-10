using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    //para poder almacenarlos 
    public List<Seleccion> seleccionsCar;
    //instancia del objeto
    public void Awake()
    {
        if(GameManager.Instance == null)
        {
            GameManager.Instance = this;
            //para poder pasar la seleccion entre escenas
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //si ya existe se destruye
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
