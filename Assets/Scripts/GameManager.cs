using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab; // Asigna el prefab del jugador desde el Inspector.
  
  
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // Instancia el prefab del jugador en la posici�n y rotaci�n deseadas.
        GameObject playerInstance = Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        // Asigna el nombre del jugador para una mejor identificaci�n en la jerarqu�a.
        playerInstance.name = "Player";
        playerInstance.tag = "Player";
        



    }
}