using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="question",menuName ="Inventory/question")]
public class question : ScriptableObject
{
    public List<string> answers=new List<string>();
    public List<bool> rightAnswer = new List<bool>();
}