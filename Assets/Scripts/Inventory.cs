using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        public int count;
        public int maxQuantity;
        public CollectableType type;
        //Set Slot to default values
        public Slot()
        {
            count = 0;
            maxQuantity = 20;
            type = CollectableType.NONE;
        }
        //Check if can add based on quantity
        public bool CanAdd()
        {
          return count < maxQuantity;
        }
        //Add to the count
        public void Add(CollectableType type)
        {
            count++;
        }
    }
    //Create a list of slots
    public List<Slot> slots = new List<Slot>();
    public Inventory(int numSlots) 
    { 
        for (int i = 0; i < numSlots; i++)
        {
            slots.Add(new Slot());
        }

    }
    // Add item to inventory and return true if successful
    public bool AddItem(CollectableType type)
    {
        // Buscar si el item ya está en el inventario
        Slot existingSlot = slots.Find(slot => slot.type == type);

        if (existingSlot != null)
        {
            // Si el item ya está en el inventario, incrementar la cantidad en ese slot
            if (existingSlot.CanAdd())
            {
                existingSlot.count++;
                return true;
            }
            else
            {
                // No se puede añadir más al slot, inventario lleno
                return false;
            }
        }
        else
        {
            // Buscar un slot vacío
            Slot emptySlot = slots.Find(slot => slot.type == CollectableType.NONE);

            if (emptySlot != null)
            {
                // Si hay un slot vacío, asignar el tipo y añadir el item
                emptySlot.type = type;
                emptySlot.count++;
                return true;
            }
            else
            {
                // Si no hay un slot vacío, el inventario está lleno
                return false;
            }
        }
    }


}
