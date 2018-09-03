using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public Rigidbody rigid;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
	}
}
