using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public GameObject slotGrid;
    public GameObject emptyslot;
    public Text itemInfo;
    public Inventory Mybag;
    public List<GameObject> slots = new List<GameObject>();
    public int totalItem;
    public Text notget;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        totalItem = Mybag.itemlist.Count;
        RefreshItem();
    }

    public static void UpdateItemInfo(string info)
    {
        instance.itemInfo.text = info;
    }

    public void RefreshItem()
    {
        int nowItem=0;
        Debug.Log("refresh");
        int tempChildcount = instance.slotGrid.transform.childCount;
        for(int i=0;i<tempChildcount;i++)
        {
            if (instance.slotGrid.transform.childCount==0)
            {
                break;
            }
            var tempSlot=instance.slotGrid.transform.GetChild(0).gameObject;
            tempSlot.transform.SetParent(transform);
            Destroy(tempSlot);
        }
        instance.slots.Clear();
        Debug.Log(slotGrid.transform.childCount);
        for (int i=0;i<instance.Mybag.itemlist.Count;i++)
        {
            Debug.Log(i);
            if (instance.Mybag.itemlist[i].itemHeld != 0) nowItem++;
            var tempslot = Instantiate(emptyslot);
            instance.slots.Add(tempslot);
            instance.slots[i].transform.SetParent(slotGrid.transform);
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(Mybag.itemlist[i]);
        }
        Debug.Log(slotGrid.transform.childCount);
        slotGrid.GetComponent<UIRotate>().refresh();
        notget.text = "您还有" + (totalItem - nowItem).ToString()+"片碎片未获得";
    }
}