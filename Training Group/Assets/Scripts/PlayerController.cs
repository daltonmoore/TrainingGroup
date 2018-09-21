using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController pc;
    public int maxWeaponIndex;
    public int damage;
    public int ammoCount;
    public int ammoMax;
    public float moveSpeed = 20f;
    public float fireForce;
    public GameObject fists;
    public GameObject gun;
    public GameObject sword;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;
    public TextMesh ammoTextMesh;
    public AudioSource pistolSound;

    int coinCounter;
    int weaponIndex = 1;
    Rigidbody rigid;
    Animator anim;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        pc = this;
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
	
	void Update ()
    {
        try
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            move();

            if (scroll > 0)
            {
                changeWeapon();
            }

            fire();
        }
        catch (Exception e)
        {
            UnityEditor.EditorUtility.DisplayDialog("Error in PlayerController Update", e.Message, "ok");
            Debug.Break();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Chaser c = other.gameObject.GetComponent<Chaser>();
            c.health -= damage;
        }
    }

    void fire()
    {
        if (Input.GetMouseButtonDown(0) && ammoCount > 0)
        {
            if (weaponIndex == 0)
            {
                //anim.SetTrigger("leftPunch");
            }
            else if (weaponIndex == 1)
            {
                pistolSound.Play();
                GameObject g = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
                Rigidbody r = g.GetComponent<Rigidbody>();
                r.AddForce(gun.transform.forward * fireForce);
                Destroy(g, 2f);
                ammoCount--;
                ammoTextMesh.text = "" + ammoCount;
            }
            else if(weaponIndex == 2)
            {
                anim.SetTrigger("SwingSword01");
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = ammoMax;
            ammoTextMesh.text = "" + ammoCount;
            anim.SetTrigger("Reload");
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (weaponIndex == 0)
            {
                //anim.SetTrigger("rightPunch");
            }
        }
    }

    void changeWeapon()
    {
        if(weaponIndex == 0)
        {
            weaponIndex++;
            //fists.SetActive(false);
            gun.SetActive(true);
        }
        else if(weaponIndex == 1)
        {
            weaponIndex++;
            gun.SetActive(false);
            sword.SetActive(true);
        }
        else if(weaponIndex == 2)
        {
            weaponIndex++;
            sword.SetActive(false);
        }
        if(weaponIndex > maxWeaponIndex)
        {
            fists.SetActive(true);
            weaponIndex = 0;
        }
    }

    void move()
    {
        if (UI.ui.inDialog == false)
        {
            transform.forward = Camera.main.transform.forward;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (rigid.velocity.z < 5)
                {
                    rigid.AddForce(Camera.main.transform.forward * moveSpeed * Time.deltaTime);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (rigid.velocity.z > -5)
                {
                    rigid.AddForce(-Camera.main.transform.forward * moveSpeed * Time.deltaTime);
                }
            }

            /*if (Input.GetKey(KeyCode.LeftArrow))
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
            }*/
        }
    }
}
