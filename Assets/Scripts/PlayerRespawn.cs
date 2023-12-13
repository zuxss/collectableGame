using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform currentRespawn; //Store Checkpoint for respawn

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }


    public void Respawn()
    {
            transform.position = currentRespawn.position;
            playerHealth.ResetHealth();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnPlayer"))
        {
            currentRespawn = collision.transform;
        }
    }
}


