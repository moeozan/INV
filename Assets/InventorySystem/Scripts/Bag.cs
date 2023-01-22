using Inv;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    public GameObject informationPanel;
    public Image itemImage;
    private GameObject inf;
    private bool locked;
    private Slot choosenSlot;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
        inf = Instantiate(informationPanel);
    }

    void Start()
    {
        raycaster = GetComponentInParent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);
        itemImage.transform.position = Input.mousePosition;
        if (results.Count < 1)
        {
            inf.SetActive(false);
            return;
        }
        else
        {
            foreach (RaycastResult result in results)
            {
                Slot temp = result.gameObject.GetComponent<Slot>();
                if (locked && choosenSlot != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (result.gameObject.GetComponent<Trash>())
                        {
                            inventory.UpdateInventoryData(choosenSlot);
                        }
                        else if (result.gameObject.GetComponent<Slot>())
                        {
                            inventory.UpdateInventoryData(choosenSlot, temp);
                        }
                        choosenSlot.choosen.gameObject.SetActive(false);
                        itemImage.gameObject.SetActive(false);
                        choosenSlot = null;
                        locked = false;
                        return;
                    }
                }

                if (!temp)
                    return;

                if (Input.GetMouseButtonDown(0))
                {
                    locked = true;
                    itemImage.gameObject.SetActive(true);
                    choosenSlot = temp;
                    itemImage.sprite = choosenSlot._item.ItemInfo.sprite;
                    temp.choosen.gameObject.SetActive(true);
                    return;
                }

                if (temp.IsEmpty)
                {
                    inf.SetActive(false);
                    return;
                }
                SetInformation(temp);
            }
        }
    }

    private void SetInformation(Slot slot)
    {
        if (slot.IsEmpty)
            return;
        inf.SetActive(true);
        inf.transform.SetParent(slot.informationPanelTransform);
        inf.transform.position = slot.informationPanelTransform.position;
        Information info = inf.GetComponent<Information>();
        info.itemName.text = slot._item.ItemInfo.Name;
        info.itemDescription.text = slot._item.ItemInfo.Description;
    }
}
