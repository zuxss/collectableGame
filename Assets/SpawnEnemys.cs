using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public DayNightCycleController dayNightCycle;
    [SerializeField]  public GameObject enemyPrefab;
    public Transform[] spawnPoints;
   
    private void Start()
    {
        dayNightCycle.OnCycleChanged += HandleCycleChanged;
    }



    private void HandleCycleChanged(int newCycleIndex)
    {
        // Verificar si es de noche (ciclo de noche con índice 2)
        if (newCycleIndex == 2)
        {
            // Activar enemigosNight
            Spawn();
        }
        else
        {
            
           DestroyEnemies();
        }
    }

     void Spawn()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                    
        }

    }


    void DestroyEnemies()
    {   
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Skeleton");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
            
        }
       
    }
}
