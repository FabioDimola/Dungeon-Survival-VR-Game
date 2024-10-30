using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlots;

    public void ShowItem(ItemS item)
    {
       for(int i = 0; i < itemSlots.Length; i++)
        {
            
                itemSlots[i].ShowItem(item);
                return;
            
        }
    }
}
