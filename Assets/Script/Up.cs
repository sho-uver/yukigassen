using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Up : MonoBehaviour
{
    GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerUp(GameObject gameObject)
    {
        UpTrue(gameObject);
    }

    public void UpTrue(GameObject gameObject)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventDate) => { gameObject.GetComponent<player>().UpFlagTrue(); });
        trigger.triggers.Add(entry);
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((eventDate) => { gameObject.GetComponent<player>().UpFlagFalse(); });
        trigger.triggers.Add(entry2);
    }
}
