using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class camera : MonoBehaviour
{
    GameObject target;
    public float height;
    public float distance;
    Vector3 d;
    bool RAngleFlag;
    bool LAngleFlag;
    // Start is called before the first frame update
    void Start(){    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R) || RAngleFlag)
        {
            RAngle();
        }
        if(Input.GetKey(KeyCode.L) || LAngleFlag)
        {
            LAngle();
        }
        // transform.LookAt(target.transform);
        d = transform.forward * distance + transform.up * height;
        transform.position = target.transform.position + d;
        
    }

    public void SetTarget(GameObject player)
    {
        target = player;
    }

    public void RAngleFlagTrue()
    {
        RAngleFlag = true; 
    }
        public void RAngleFlagFalse()
    {
        RAngleFlag = false; 
    }
        public void LAngleFlagTrue()
    {
        LAngleFlag = true; 
    }
        public void LAngleFlagFalse()
    {
        LAngleFlag = false; 
    }
    public void RAngle()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 5);
    }

    public void LAngle()
    {
        transform.RotateAround(target.transform.position, Vector3.up, -5);
    }
}
