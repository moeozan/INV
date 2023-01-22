using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inv
{
    public class Inventory : MonoBehaviour

    {
        [SerializeField] private InventoryData data;
        public InventoryData Data { get { return data; } set { data = value; } }

        [Header("Child Game Objects")]
        [SerializeField] private GameObject Bag;


        private void Awake()
        {
            for (int i = 0; i < data.SlotAmount; i++)
            {
                GameObject s = Instantiate(data.SlotPrefab);
                s.transform.SetParent(Bag.transform);
                s.GetComponent<Slot>().Index = i;
            }
        }

        public void UpdateInventoryData(Slot slotOne,Slot slotTwo)
        {
            //Debug.Log(slotOne.Index + " / "  + slotTwo.Index);
            if (!slotTwo._item)
            {
                data.Items[slotTwo.Index] = slotOne._item;
                data.Items[slotOne.Index] = null;
                slotTwo.Setup();
                slotOne.Setup();
                return;
            }
            data.Items[slotOne.Index] = slotTwo._item;
            data.Items[slotTwo.Index] = slotOne._item;
            slotOne.Setup();
            slotTwo.Setup();
        }
        public void UpdateInventoryData(Slot slot)
        {
            data.Items[slot.Index] = null;
            slot.Setup();
        }
    }
}