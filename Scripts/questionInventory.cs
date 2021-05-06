using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="questionInventory",menuName ="questionInventory")]
public class questionInventory : ScriptableObject
{
    public List<bool> questions = new List<bool>();
}