using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palaceSpriteDeepin : MonoBehaviour
{
    public GameObject[] sprites;

    float basedeepin = 2.0f;
    float addDeepin=0f;
    // Start is called before the first frame update

    void setDeepin(int index)
    {
        Vector3 tempvec = sprites[index].transform.localPosition ;
        sprites[index].transform.position = new Vector3(tempvec.x, tempvec.y, basedeepin - index * addDeepin);
    }

    void Start()
    {
        int childCount = transform.childCount;
        addDeepin = 4.0f / childCount;
        sprites = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
            sprites[i] = transform.GetChild(i).gameObject;
        Debug.Log("getSprites");
        for (int i = 0; i < childCount-2; i++)
            setDeepin(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
