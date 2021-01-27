using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject target;
    public float height;
    public float distance;
    Vector3 d;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("yukigassenPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            transform.RotateAround(target.transform.position, Vector3.up, 5);
        }
        if(Input.GetKey(KeyCode.L))
        {
            transform.RotateAround(target.transform.position, Vector3.up, -5);
        }
        // transform.LookAt(target.transform);
        d = transform.forward * distance + transform.up * height;
        transform.position = target.transform.position + d;
        
    }
}
