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
            Vector3 playerPosition = collision.transform.position;

            // Calcula la direcci�n del empuje (asumiendo movimiento hacia la izquierda)
            Vector3 pushDirection = Vector3.left;

            // Mueve al jugador en la direcci�n del empuje y la distancia especificada
            collision.transform.position = playerPosition + pushDirection * pushForce;
        }
    }

    private void DealDamage(GameObject player)
    {

       
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

}



