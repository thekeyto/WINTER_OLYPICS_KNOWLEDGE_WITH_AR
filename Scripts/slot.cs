using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public int slotID;
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public GameObject itemInSlot;
    public string slotInfo;
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotInfo);
    }

    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            //itemInSlot.SetActive(false);
            return;
        }
        Debug.Log(item.name);
        slotItem = item;
        slotImage.sprite = item.itemImage;
        if (item.itemHeld == 0) slotImage.color = Color.black;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}