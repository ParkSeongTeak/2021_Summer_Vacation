using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EventTriggerEX : MonoBehaviour
{
    EventTrigger eventTrigger;
    void Start()
    {
        init();
    }

    private void init()
    {
        
        gameObject.AddComponent<EventTrigger>();
        eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

        EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
        entry_Drag.eventID = EventTriggerType.Drag;
        entry_Drag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Drag);

        EventTrigger.Entry entry_EndDrag = new EventTrigger.Entry();
        entry_EndDrag.eventID = EventTriggerType.EndDrag;
        entry_EndDrag.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_EndDrag);

        EventTrigger.Entry entry_Click = new EventTrigger.Entry();
        entry_Click.eventID = EventTriggerType.PointerClick;
        entry_Click.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click);


        EventTrigger.Entry entry_PointerExit = new EventTrigger.Entry();
        entry_PointerExit.eventID = EventTriggerType.PointerExit;
        entry_PointerExit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerExit);

        EventTrigger.Entry entry_PointerEnter = new EventTrigger.Entry();
        entry_PointerExit.eventID = EventTriggerType.PointerEnter;
        entry_PointerExit.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerEnter);

    }
    public void OnPointerExit(PointerEventData data)
    {

        Debug.Log($"OnPointerExit {(data.pointerCurrentRaycast.gameObject != null ? data.pointerCurrentRaycast.gameObject.name : "NULL") }");

        //TODO
    }
    void OnPointerDown(PointerEventData data)
    {
        Debug.Log($"OnPointerDown {(data.pointerCurrentRaycast.gameObject != null ? data.pointerCurrentRaycast.gameObject.name : "NULL") }");
        //TODO
    }

    void OnDrag(PointerEventData data)
    {
        //TODO
        //ex)
        //UiDragImage.transform.position = data.position;
        //드래그로 UI이미지를 끌고다니는 코드
        Debug.Log($"OnDrag {(data.pointerCurrentRaycast.gameObject != null ? data.pointerCurrentRaycast.gameObject.name : "NULL") }");

    }

    void OnEndDrag(PointerEventData data)
    {
        //TODO
        Debug.Log($"OnEndDrag {(data.pointerCurrentRaycast.gameObject != null ? data.pointerCurrentRaycast.gameObject.name : "NULL") }");

    }

    void OnPointerClick(PointerEventData data)
    {
        //TODO
        Debug.Log($"OnPointerClick {(data.pointerCurrentRaycast.gameObject != null ? data.pointerCurrentRaycast.gameObject.name : "NULL") }");

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerEnter.transform.Translate(new Vector3(50, 0, 0));
    }

}
