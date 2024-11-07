using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

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
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);
        gamePause = true;
        Debug.Log("Pausaaaaa");
    }
    public void Resume() {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
        gamePause = false;
        Debug.Log("Resumen");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gamePause = false;
    }

    public void Quit()
    {
        Debug.Log("Cerrar juego");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        gamePause = false;
    }
}
