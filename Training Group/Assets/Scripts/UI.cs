using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI ui;
    public GameObject dialogueOverlay;
    public Text dialogueText;
    public Text coinCounterText;
    public bool inDialog = false;

    PlayerController pc;
    string[] lines;
    int curLine;
    int endLine;
    

    public void StartDialog(TextAsset textAsset)
    {
        dialogueOverlay.SetActive(true);
        lines = textAsset.text.Split('\n');
        curLine = 0;
        endLine = lines.Length - 1;
        inDialog = true;
    }

	// Use this for initialization
	void Start ()
    {
        if (ui == null)
            ui = this;
        else if (ui != null)
            Destroy(this);

        dialogueOverlay.SetActive(false);
        pc = PlayerController.pc;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(inDialog)
        {
            dialogueText.text = lines[curLine];
            if(Input.GetKeyDown(KeyCode.Space))
            {
                curLine++;
                if(curLine > endLine)
                {
                    dialogueOverlay.SetActive(false);
                    Time.timeScale = 1;
                    inDialog = false;
                }
            }
        }
	}

    public void fireCollectable()
    {
        pc.incrementCoins();
        coinCounterText.text = pc.getCoins().ToString();
    }
}
