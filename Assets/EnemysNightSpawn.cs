using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysNightSpawn : MonoBehaviour
{
    public DayNightCycleController dayNightCycle;
    public GameObject enemys;

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
            SpawnEnemys();
        }
        else
        {
            // Desactivar enemigosNight
            enemys.SetActive(false);
        }
    }

    private void SpawnEnemys()
    {
       
        enemys.SetActive(true);
    }
}
