using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public TextAsset dialogueText;

    bool canTalk = false;

    private void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0;
            try
            {
                UI.ui.StartDialog(dialogueText);
            }
            catch(Exception e)
            {
                UnityEditor.EditorUtility.DisplayDialog("Error in NPCTrigger Update", e.Message, "ok");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            canTalk = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canTalk = false;
    }
}
