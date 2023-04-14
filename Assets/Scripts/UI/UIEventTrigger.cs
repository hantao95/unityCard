using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


//ÊÂ¼þ¼àÌý
public class UIEventTrigger : MonoBehaviour, IPointerClickHandler
{
    public Action<GameObject,PointerEventData> onClick;

    public static UIEventTrigger Get(GameObject obj)
    {
        UIEventTrigger uIEventTrigger = obj.GetComponent<UIEventTrigger>();
        if (uIEventTrigger == null)
        {
            uIEventTrigger = obj.AddComponent<UIEventTrigger>();
        }
        return uIEventTrigger;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null)
        {
            onClick(gameObject, eventData);
        }
    }
}
