using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed = 5f;

    //Vector3 offset = new Vector3(0, .5f, -2);

	// Use this for initialization
	void Start () {
		
	}

    float timer;
	// Update is called once per frame
	void Update ()
    {
        transform.position = player.transform.position;// + offset;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed, 0);
        }
        /*else if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(turnSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-turnSpeed, 0, 0);
        }*/

        /*
        transform.LookAt(player.transform);
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 movementX = x * Camera.main.transform.right;
        Vector3 movementY = y * Camera.main.transform.up;

        
        Vector3 newPos = transform.position + movementX + movementY;

        Vector3 offset = newPos - player.transform.position;
        transform.position = player.transform.position + Vector3.ClampMagnitude(offset, radius);
        */
    }
}
