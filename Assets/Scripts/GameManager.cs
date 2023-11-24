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
        // Instancia el prefab del jugador en la posición y rotación deseadas.
        GameObject playerInstance = Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        // Asigna el nombre del jugador para una mejor identificación en la jerarquía.
        playerInstance.name = "Player";
        playerInstance.tag = "Player";
        



    }
}
