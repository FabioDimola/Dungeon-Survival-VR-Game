using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] ItemType itemType;
    public ItemType ItemType => itemType;

    public float duration = 30f;





}

public enum ItemType
{
    Potion,
    Shield,
    Weapon,
    Coin
}
