using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    //variables de objetos
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;
    //para boton de teclado 
    private bool gamePause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePause)
            {
                Resume();
            }
            else { 
                Pause();
            }
        }
    }
    public void Pause() { 
        //para que el tiempo en el juego se detenga
        Time.timeScale = 0f;
        //desactivar boton pausa
        buttonPause.SetActive(false);
        //activar menu
        menuPause.SetActive(true);
        gamePause = true;
        Debug.Log("Pausaaaaa");
    }
    public void Resume() {
        Time.timeScale = 1f;
        //activar pausa
        buttonPause.SetActive(true);
        // descativar menu
        menuPause.SetActive(false);
        gamePause = false;
        Debug.Log("Resumen");
    }

    public void Restart()
    {
        Time.timeScale = 1f; 
        //recargamos la escena (name)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gamePause = false;
    }

    public void Quit()
    {
        Debug.Log("Cerrar juego");
        Time.timeScale = 1f;//tiempo de juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        gamePause = false;
    }
}
