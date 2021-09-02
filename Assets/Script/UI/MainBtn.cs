using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject btn;

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerEnter.transform.Translate(new Vector3(50, 0, 0));
        btn = eventData.pointerEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btn.transform.Translate(new Vector3(-50, 0, 0));
    }
}
