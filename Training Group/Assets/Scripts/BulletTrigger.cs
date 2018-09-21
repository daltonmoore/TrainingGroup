using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Chaser c = other.gameObject.GetComponent<Chaser>();
            if(c!=null)
                c.health -= damage;
        }
    }
}
