using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 moveDirection;
    GameObject MainCamera;
    Transform MCT;
    float front;
    float back;
    float left;
    float right;
    public float speed;
    GameObject yukidama;
    Animator animator;
    bool damageFlag; 
    bool upArrowFlag;
    bool downArrowFlag;
    bool leftArrowFlag;
    bool rightArrowFlag;
    bool shootFlag;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        MCT = MainCamera.transform;
        yukidama = (GameObject)Resources.Load ("yukidama");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damageFlag)
        {
            transform.Rotate(0,10,0);
            return; 
        }

        // UpArrow
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            // カメラに対して前を向く
            front = MCT.localEulerAngles.y - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, front ,0));
            Move();
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            Wait();
        }

        // DownArrow
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            // カメラの向きに対して後ろを向く
            back = MCT.localEulerAngles.y + 180 - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, back ,0));
            Move();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            Wait();
        }

        // RightArrow
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = MCT.localEulerAngles.y + 90 - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, right ,0));
            Move();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            Wait();
        }

        // leftArrow
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = MCT.localEulerAngles.y - 90 - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, left ,0));
            Move();
        }        
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Wait();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("shoot", false);
        }
        transform.Translate(moveDirection);
        
    }

    void Move()
    {
        moveDirection = Vector3.forward * speed;
        animator.SetBool("walk", true);
        animator.SetBool("wait", false);
        // walkのflagをtureに変更
    }

    void Wait()
    {
        moveDirection = Vector3.forward * 0;
        animator.SetBool("walk", false);
        animator.SetBool("wait", true);
        // waitのflagをtureに変更
    }

    void Shoot()
    {
        Instantiate(yukidama, transform.position + transform.forward * 3, Quaternion.identity);
        animator.SetBool("shoot", true);
    }

    void Damage()
    {
        animator.SetBool("damage", true);
        damageFlag = true;
        Invoke("DamageRecover", 1);
        Wait();
        Debug.Log("get");
    }

    void DamageRecover()
    {
        animator.SetBool("damage", false);
        damageFlag = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "yukidama")
        {
            Damage();
        }
    }

    void OnClickShoot()
    {
        shootFlag = true;
    }
}
