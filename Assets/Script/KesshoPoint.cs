using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KesshoPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKesshoPoint(int k, int ek)
    {
        GameObject.GetComponent<Text>().text = "PLAYERPOINT:" + k + " ENEMYPOINT:" + ek;
    }
}
