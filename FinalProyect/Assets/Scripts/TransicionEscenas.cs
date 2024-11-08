 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransicionEscenas : MonoBehaviour
{
    public static TransicionEscenas Instance;
    [Header("Disolver")]
    public CanvasGroup disolverCanvasGroup;
    public float timeDisolver;
    public float timeDissolveSalida;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { 
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DisolverEscena();    
    }

    private void DisolverEscena()
    {
        LeanTween.alphaCanvas(disolverCanvasGroup, 0f, timeDisolver).setOnComplete(() =>
            {
                disolverCanvasGroup.blocksRaycasts = false;
                disolverCanvasGroup.interactable = false;
            }
        );
    }

    public void DisolverSalida(int indexEscena)
    {
        disolverCanvasGroup.blocksRaycasts = true;
        disolverCanvasGroup.interactable= true;

        LeanTween.alphaCanvas(disolverCanvasGroup, 2f, timeDissolveSalida).setOnComplete(() =>
        {
            SceneManager.LoadScene(indexEscena);
        }
        );
    }
}
