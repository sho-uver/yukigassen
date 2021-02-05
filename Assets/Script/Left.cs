using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour
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

    public void SetPlayerLeft(GameObject gameObject)
    {
        LeftTrue(gameObject);
    }

    public void LeftTrue(GameObject gameObject)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventDate) => { gameObject.GetComponent<player>().LeftFlagTrue(); });
        trigger.triggers.Add(entry);
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((eventDate) => { gameObject.GetComponent<player>().LeftFlagFalse(); });
        trigger.triggers.Add(entry2);
    }
}