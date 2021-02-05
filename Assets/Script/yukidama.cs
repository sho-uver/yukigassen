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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject.Destroy(gameObject);
    }

    public void Melt()
    {
        GameObject.Destroy(gameObject);
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        moveDirection = player.transform.forward;
        Invoke("Melt", 2);
    }
}
