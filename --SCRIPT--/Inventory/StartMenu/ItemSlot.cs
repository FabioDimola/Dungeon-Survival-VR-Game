using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{

    //===Item Data===//
    public ItemS item;

      string itemName;
      
      string itemDescription;

    public bool selected = false;
    //==Info Panel==//
    [SerializeField] private TMP_Text descriptionTXT;
    [SerializeField] private Image icon;

    private GameObject itemPrefab;
    Toggle toggle;


    public Transform showPosition;
    public GameObject prefab;
    private void Awake()
    {
        this.icon.sprite = item.sprite;
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { ShowPrefab(); });
    }

    public void ShowItem(ItemS item)
    {
       
        
        this.itemName = item.name;
        this.itemDescription = item.description;
       

        descriptionTXT.text = item.description;

    }


    public void DeselectItem(ItemS item)
    {
       if(itemPrefab != null)
        {
            itemPrefab.SetActive(false);
            this.itemName = null;
            this.itemDescription = null;    
        }

    }

    public void ShowPrefab()
    {
      
        
     
    }

}
