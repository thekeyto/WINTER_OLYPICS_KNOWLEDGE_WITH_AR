using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIRotate : MonoBehaviour
{
    int halfSize;
    public GameObject[] gameObjects;
    private int r = 300;
    float angle;
    public Text itemInfo;

    void setPostion(int index)
    {
        float x = 0;
        float z = 0;

        /*int childcount = gameObjects.Length;
        if (childcount%2==0)
        {
            x= -r * Mathf.Cos(angle * index * Mathf.Deg2Rad);
            z=
        }
        */
        if (index < halfSize)
        {
            int id = halfSize - index;
            x = r * Mathf.Sin(angle * id*Mathf.Deg2Rad);
            z = -r * Mathf.Cos(angle * id * Mathf.Deg2Rad);
        }
        else if (index > halfSize)
        {
            int id = index - halfSize;
            x = -r * Mathf.Sin(angle * id * Mathf.Deg2Rad);
            z = -r * Mathf.Cos(angle * id * Mathf.Deg2Rad);
        }
        else
        {
            x = 0;
            z = -r;
        }
        Debug.Log(index.ToString() +" "+x.ToString()+" "+z.ToString());
        Tween tweener = gameObjects[index].GetComponent<RectTransform>().DOLocalMove(new Vector3(x, 0, z), 1);
    }

    void setDeepin(int index,int direct)
    {
        int deepin = 0;
        if (index<halfSize)
        {
            if(direct==1)
            deepin = index;
            else deepin = gameObjects.Length - (1 + index);
        }
        else if (index>halfSize)
        {
            if(direct==1)
            deepin = gameObjects.Length - (1 + index);
            else
                deepin = index;
        }
        else
        {
            deepin = halfSize;
        }
        gameObjects[index].GetComponent<RectTransform>().SetSiblingIndex(deepin);
    }

    public void leftNext()
    {
        int length = gameObjects.Length;
        var temp = gameObjects[length - 1];
        for(int i=length-1;i>0;i--)
        {
            gameObjects[i] = gameObjects[i - 1];
        }
        gameObjects[0] = temp;
        for(int i=0;i<length;i++)
        {
            setPostion(i);
            setDeepin(i,0);
        }
        if (gameObjects[length / 2].GetComponent<slot>().slotItem.itemHeld > 0)
            itemInfo.text = gameObjects[length / 2].GetComponent<slot>().slotItem.itemInfo;
        else
            itemInfo.text = "暂未获得";
    }

    public void rightNext()
    {
        int length = gameObjects.Length;
        var temp = gameObjects[0];
        for (int i = 0; i < length - 1; i++)
        {
            gameObjects[i] = gameObjects[i + 1];
        }
        gameObjects[length-1] = temp;
        for (int i = 0; i < length; i++)
        {
            setPostion(i);
            setDeepin(i,1);
        }
        if (gameObjects[length / 2].GetComponent<slot>().slotItem.itemHeld > 0)
            itemInfo.text = gameObjects[length / 2].GetComponent<slot>().slotItem.itemInfo;
        else
            itemInfo.text = "暂未获得";
    }
    public void refresh()
    {
        int childCount = transform.childCount;
        Debug.Log(childCount);
        halfSize = (childCount - 1) / 2;
        angle = 360 / childCount;
        gameObjects = new GameObject[childCount];
        Debug.Log(angle);
        for(int i=0;i< childCount;i++)
        {
            gameObjects[i] = transform.GetChild(i).gameObject;
        }
        Debug.Log("rotate");
        for (int i = 0; i < childCount; i++)
        {
            setPostion(i);
            setDeepin(i,0);
        }
        if (gameObjects[childCount / 2].GetComponent<slot>().slotItem.itemHeld > 0)
            itemInfo.text = gameObjects[childCount / 2].GetComponent<slot>().slotItem.itemInfo;
        else
            itemInfo.text = "暂未获得";
    }
}
