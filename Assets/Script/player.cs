using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
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
    bool upFlag;
    bool downFlag;
    bool leftFlag;
    bool rightFlag;
    bool shootFlag;
    bool playerFlag;
    GameObject gameSystem;

    

    // Start is called before the first frame update
    void Start()
    {
        if (!playerFlag){return; }
        MainCamera = GameObject.Find("Main Camera");
        MCT = MainCamera.transform;
        yukidama = (GameObject)Resources.Load ("yukidama");
        animator = GetComponent<Animator>();
        gameSystem = GameObject.Find("GameSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerFlag){return; }
        if(damageFlag)
        {
            transform.Rotate(0,10,0);
            return; 
        }

        // UpArrow
        if(Input.GetKey(KeyCode.UpArrow) || upFlag)
        {
            
            front = MCT.localEulerAngles.y - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, front ,0));
            Move();
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            Wait();
        }

        // DownArrow
        if(Input.GetKey(KeyCode.DownArrow) || downFlag)
        {
            // カメラの向きに対して後ろを向く
            back = MCT.localEulerAngles.y + 180 - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, back ,0));
            Move();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) )
        {
            Wait();
        }

        // RightArrow
        if(Input.GetKey(KeyCode.RightArrow) || rightFlag)
        {
            right = MCT.localEulerAngles.y + 90 - transform.localEulerAngles.y;
            transform.Rotate(new Vector3(0, right ,0));
            Move();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) )
        {
            Wait();
        }

        // leftArrow
        if(Input.GetKey(KeyCode.LeftArrow) || leftFlag)
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
    }

    public void Move()
    {
        moveDirection = Vector3.forward * speed;
        animator.SetBool("walk", true);
        animator.SetBool("wait", false);
        transform.Translate(moveDirection);
    }

    public void Wait()
    {
        moveDirection = Vector3.forward * 0;
        transform.Translate(moveDirection);
        animator.SetBool("walk", false);
        animator.SetBool("wait", true);
    }

    public void Shoot()
    {
        gameSystem.GetComponent<GameSystem>().Yukidama(transform.position + transform.forward * 3);
        animator.SetTrigger("shoot");
    }

    public void Damage()
    {
        animator.SetBool("damage", true);
        damageFlag = true;
        Invoke("DamageRecover", 1);
        Wait();
        gameSystem.GetComponent<GameSystem>().DamageKessho();
    }

    public void DamageRecover()
    {
        animator.SetBool("damage", false);
        damageFlag = false;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "yukidama")
        {
            Damage();
        }

        if(collider.gameObject.tag == "kessho")
        {
            GetKessho();
        }
    }

    public void UpFlagTrue()
    {
        upFlag = true;
    }
    public void UpFlagFalse()
    {
        upFlag = false;
        Wait();
    }
    
    public void DownFlagTrue()
    {
        downFlag = true;
    }
    public void DownFlagFalse()
    {
        downFlag = false;
        Wait();
    }

    public void RightFlagTrue()
    {
        rightFlag = true;
    }
    public void RightFlagFalse()
    {
        rightFlag = false;
        Wait();
    }

    public void LeftFlagTrue()
    {
        leftFlag = true;
    }
    public void LeftFlagFalse()
    {
        leftFlag = false;
        Wait();
    }

    public void SetPlayerFlag(bool flag)
    {
        playerFlag = flag;
    }

    public void GetKessho()
    {
        gameSystem.GetComponent<GameSystem>().GetKessho();
    }

}
