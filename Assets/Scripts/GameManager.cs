using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab; // Asigna el prefab del jugador desde el Inspector.
    public static GameManager Instance;
  
  
    void Awake()
    {
        SpawnPlayer();
        Instance = this;
    }

    void SpawnPlayer()
    {
        // Instancia el prefab del jugador en la posición y rotación deseadas.
        GameObject playerInstance = Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        // Asigna el nombre del jugador para una mejor identificación en la jerarquía.
        playerInstance.name = "Player";
        playerInstance.tag = "Player";
    }

    public void GameOver()
    {
       
        Debug.Log("Game Over");
    }
}
