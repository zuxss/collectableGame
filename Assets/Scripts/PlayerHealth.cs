using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxLifePoints ;
    public float currentLifePoints;
    [SerializeField] private PlayerHealthBar healthBar;
    void Start()
    {
        currentLifePoints = maxLifePoints;
        healthBar.InitialateHealthBar(currentLifePoints);
      
      
    }

  
    public void TakeDamage(float damage)
    {
        currentLifePoints -= damage;
        healthBar.ChangeLifePoints(currentLifePoints);
        if (currentLifePoints <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }


}
