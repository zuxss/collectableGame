using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public DayNightCycleController dayNightCycle;
    public Transform[] spawnPoints;
    [SerializeField]  public GameObject enemyPrefab;
    [SerializeField] public GameObject redBookPrefab;
   
    
    private void Start()
    {
        dayNightCycle.OnCycleChanged += HandleCycleChanged;
       
    }



    private void HandleCycleChanged(int newCycleIndex)
    {
        // Verificar si es de noche (ciclo de noche con índice 2)
        if (newCycleIndex == 2)
        {
            // Activar 
         
                SpawnSkeleton();
                redBookPrefab.SetActive(true);
            
           
        }
        else
        {
            
           DestroyEnemies();
            redBookPrefab.SetActive(false);
        }
    }

     void SpawnSkeleton()
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
