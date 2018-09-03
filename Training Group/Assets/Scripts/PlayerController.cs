using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController pc;
    public float moveSpeed = 20f;

    int coinCounter;
    Rigidbody rigid;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pc = this;
    }

    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody>();
	}

    public int getCoins()
    {
        return coinCounter;
    }

    public void incrementCoins()
    {
        coinCounter++;
    }
	
	// Update is called once per frame
	void Update ()
    {
        move();
	}

    void move()
    {
        transform.forward = Camera.main.transform.forward;

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("leftPunch");
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (rigid.velocity.z < 5)
            {
                rigid.AddForce(Camera.main.transform.forward * moveSpeed * Time.deltaTime);
            }
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if (rigid.velocity.z > -5)
            {
                rigid.AddForce(-Camera.main.transform.forward * moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rigid.velocity.x > -5)
            {
                rigid.AddForce(-Camera.main.transform.right * moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rigid.velocity.x < 5)
            {
                rigid.AddForce(Camera.main.transform.right * moveSpeed * Time.deltaTime);
            }
        }
    }
}
