using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;
    public void Pause() { 
        Time.timeScale = 0f;
        Debug.Log("Pausaaaaa");
    }
    public void Resume() {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
        Debug.Log("Resumen");
    }
}
