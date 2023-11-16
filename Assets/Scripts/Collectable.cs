using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public CollectableType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory player = collision.GetComponent<PlayerInventory>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            // Attemp to collect
            if (player.inventory.AddItem(type))
            {
                // If the item was added successfully, destroy the collectable
                Destroy(gameObject);
            }
        }
    }
}

public enum CollectableType
{
       NONE,BLUEBOOK,REDKEY,REDBOOK,GREENKEY,GREENBOOK 
}