using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yukidama : MonoBehaviour
{
    public float speed;
    GameObject player;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("yukigassenPlayer");
        moveDirection = player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject.Destroy(gameObject);
        Debug.Log("destroy");
    }
}
