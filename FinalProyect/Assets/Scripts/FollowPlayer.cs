using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, -10);  // Ajusta este offset según la distancia que quieras de la cámara

    // Rotación de la cámara para seguir al carro
    private Quaternion forwardRotation = Quaternion.Euler(-0.451f, 0f, 0f);
    private Quaternion reverseRotation = Quaternion.Euler(-0.451f, -180f, 0f);  // Rotación para ver hacia atrás

    // Update is called once per frame
    void LateUpdate()
    {
        // Verifica si la tecla "S" está siendo presionada para decidir la rotación
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = player.transform.rotation * reverseRotation;
        }
        else
        {
            transform.rotation = player.transform.rotation * forwardRotation;
        }

        // Ajusta la posición de la cámara con el offset
        transform.position = player.transform.position + transform.rotation * offset;
    }
}
