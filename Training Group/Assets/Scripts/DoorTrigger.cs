using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(string.Compare(UI.ui.coinCounterText.text, "5") == 0)
        {
            openDoor();
        }
	}

    void openDoor()
    {
        anim.SetBool("Opened", true);
    }
}
