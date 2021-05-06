using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Inventory playerinventory;
    public Item thisItem;
    public void addNewItem()
    {
        /*if (!playerinventory.itemlist.Contains(thisItem))
        {
            for(int i=0;i<playerinventory.itemlist.Count;i++)
            {
                if (playerinventory.itemlist[i]==null)
                {
                    playerinventory.itemlist[i] = thisItem;
                    break;
                }
            }
        }
        else*/
        {
            thisItem.itemHeld++;
        }
    }
}
