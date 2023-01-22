using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Scriptables/Item/Consumable", order = 2)]
public class Consumable : Item
{
    public enum ConsumableType
    {
        HealthPotion,
        ManaPotion,
    }
    public int amount;
    public ConsumableType Type;

    private void Awake()
    {
        itemInfo.Type = ItemType.Consumable;
    }
}
