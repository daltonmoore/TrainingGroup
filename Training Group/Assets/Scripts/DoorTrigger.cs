using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator anim;
    AudioSource openSound;

	// Use this for initialization
	void Start ()
    {
        anim = transform.parent.GetComponent<Animator>();
        openSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(string.Compare(UI.ui.coinCounterText.text, "5") == 0 && anim.GetBool("Opened") == false)
        {
            openDoor();
        }
	}

    void openDoor()
    {
        openSound.Play();
        anim.SetBool("Opened", true);
    }
}
