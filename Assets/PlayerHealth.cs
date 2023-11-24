using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLifePoints = 6;
    public int currentLifePoints;
    void Start()
    {
        currentLifePoints = maxLifePoints;
      
    }

  
    public void TakeDamage(int damage)
    {
        currentLifePoints -= damage;
        if (currentLifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }


}
