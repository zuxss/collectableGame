using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player; // Referencia al transform del jugador


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if (player != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 posicionCamara = transform.position;

            // Establecer la posición X de la cámara para seguir al jugador
            posicionCamara.x = player.position.x;

            // Establecer la posición Y de la cámara para seguir al jugador
            posicionCamara.y = player.position.y;

            // Asignar la nueva posición a la cámara
            transform.position = posicionCamara;
        }
    }
}