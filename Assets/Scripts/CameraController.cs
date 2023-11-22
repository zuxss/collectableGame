using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador

    void FixedUpdate()
    {
        if (player != null)
        {
            // Obtener la posici�n actual de la c�mara
            Vector3 posicionCamara = transform.position;

            // Establecer la posici�n X de la c�mara para seguir al jugador
            posicionCamara.x = player.position.x;

            // Establecer la posici�n Y de la c�mara para seguir al jugador
            posicionCamara.y = player.position.y;

            // Asignar la nueva posici�n a la c�mara
            transform.position = posicionCamara;
        }
    }
}