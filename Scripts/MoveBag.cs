using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveBag : MonoBehaviour,IDragHandler
{
    public Canvas canvas;
    RectTransform currentrect;
    public void OnDrag(PointerEventData eventData)
    {
        currentrect.anchoredPosition += eventData.delta;
    }
}
