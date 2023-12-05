using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance;
    [SerializeField] public GameObject enemysNight;

  
    void Awake()
    {
        
        Instance = this;
       
    }

  
  

    public void GameOver()
    {
       
        Debug.Log("Game Over");
    }
}
