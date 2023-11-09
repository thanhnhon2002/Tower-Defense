using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Setup : MonoBehaviour
{
    public void OnPointerClick(BaseEventData eventData)
    {
        Debug.Log("Click");
    }
    void Start()
    {
        // Tìm Event Trigger component ho?c thêm n?u ch?a có
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            eventTrigger = gameObject.AddComponent<EventTrigger>();
        }

        // T?o m?t Entry m?i ?? x? lý s? ki?n Pointer Click
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick; // Lo?i s? ki?n: Pointer Click

       
        //EventTrigger.TriggerEvent triggerEvent = new EventTrigger.TriggerEvent();
       
        //triggerEvent.AddListener((eventData) => GetComponent<BuildPlace>().OnPointerClick((PointerEventData)eventData));
        //entry.callback = triggerEvent;

        entry.callback.AddListener(OnPointerClick);
        // Thêm Entry vào Event Trigger
        eventTrigger.triggers.Add(entry);
    }
}
