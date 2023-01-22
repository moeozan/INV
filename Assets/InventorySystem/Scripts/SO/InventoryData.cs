using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Scriptables/InventoryData", order = 1)]
    public class InventoryData : ScriptableObject
    {
        [SerializeField] private int slotAmount;
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private List<Item> items = new List<Item>();

        public int SlotAmount { get { return slotAmount; } }
        public GameObject SlotPrefab { get { return slotPrefab; } }
        public List<Item> Items { get { return items; } set { items = value; } }
    }
}

