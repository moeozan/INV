using Inv;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool IsEmpty { get; private set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public Item _item;

    [Header("Chieldren")]
    public Image choosen;
    public TextMeshProUGUI countText;
    public Transform informationPanelTransform;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        _item = GetComponentInParent<Inventory>().Data.Items[Index];
        IsEmpty = _item == null;
        if (IsEmpty)
        {
            countText.text = string.Empty;
            GetComponent<Image>().sprite = null;
            return;
        }
        GetComponent<Image>().sprite = _item.ItemInfo.sprite;
        if (_item.ItemInfo.Type == Item.ItemType.Weapon)
        {
            Weapon item = _item as Weapon;
            Count = 0;
            countText.text = string.Empty;

        }
        else if (_item.ItemInfo.Type == Item.ItemType.Consumable)
        {
            Consumable item = _item as Consumable;
            Count = item.amount;
            countText.text = Count.ToString();
        }
    }

}
