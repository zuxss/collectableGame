using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxLifePoints ;
    public float currentLifePoints;
    public PlayerRespawn playerRespawn;
    
   

    void Start()
    {
        currentLifePoints = maxLifePoints;
     playerRespawn = GetComponent<PlayerRespawn>();
      
    }
  
  
    public void TakeDamage(float damage)
    {
        currentLifePoints -= damage;
     
        if (currentLifePoints <= 0)
        {
            playerRespawn.Respawn(); 
        }
    }

    public void ResetHealth()
    {
        currentLifePoints = maxLifePoints;
    }

}
