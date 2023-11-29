using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : Enemy
{
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colision� es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplica el da�o al jugador
           
            DealDamage(collision.gameObject);
            
          
        }
       

    }

    private void DealDamage(GameObject player)
    {

       
        if (playerHealth != null)
        {
            playerHit.SetTrigger("isHit");
            playerHealth.TakeDamage(damage);
            
        }
    }

}



