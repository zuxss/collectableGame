using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableCounterUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] public TextMeshProUGUI blueBookCounter;
    [SerializeField] public TextMeshProUGUI redBookCounter;
   
    void Start()
    {
        
        blueBookCounter.text = "0";
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInventory.inventory.slots[0].type == CollectableType.BLUEBOOK) 
        { 
       
        blueBookCounter.text = playerInventory.inventory.slots[0].count.ToString();
        }if (playerInventory.inventory.slots[1].type == CollectableType.REDBOOK)
        {
        redBookCounter.text = playerInventory.inventory.slots[1].count.ToString();
        }
        
      
    }
        
}
