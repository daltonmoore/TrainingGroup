using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, 45 * Time.deltaTime);
        transform.Rotate(Vector3.right, 45 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UI.ui.fireCollectable();
            Destroy(gameObject);
        }
    }
}
