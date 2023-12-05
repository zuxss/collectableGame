using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //Create an instance of the inventory
    public Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory(3);
    }
 }




