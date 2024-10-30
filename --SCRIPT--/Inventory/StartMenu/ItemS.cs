using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemS : MonoBehaviour
{
    public string itemName;
    [TextArea(4, 20)]
    public string description;
    public Sprite sprite;
    public int damage;
    public float defense;
    public bool isSelected = false;

    
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }


    

}
