using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public TextAsset dialogueText;
    public Camera cinematicShot;

    bool canTalk = false;
    GameObject mainCamera;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0;
            try
            {
                mainCamera.SetActive(false);
                cinematicShot.gameObject.SetActive(true);
                UI.ui.StartDialog(dialogueText);
            }
            catch(Exception e)
            {
                UnityEditor.EditorUtility.DisplayDialog("Error in NPCTrigger Update", e.Message, "ok");
            }
        }

        if(UI.ui.inDialog == false && canTalk)
        {
            cinematicShot.gameObject.SetActive(false);
            mainCamera.SetActive(true);
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
