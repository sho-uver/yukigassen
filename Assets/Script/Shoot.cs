using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour
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

    public void SetPlayerShoot(GameObject gameObject)
    {
        ShootCall(gameObject);
    }

    public void ShootCall(GameObject gameObject)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventDate) => { gameObject.GetComponent<player>().Shoot(); });
        trigger.triggers.Add(entry);
    }


}
