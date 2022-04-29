using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [Header("Elements: ")]
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;
    public static DialogueScript instance;

    [Header("Messages: ")]
    public string[] dialogueLines;
    public int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //dialogueText.text = dialogueLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        // Checkin if dialogue box is active in this moment
        if(dialogueBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                currentLine++;
                if(currentLine < dialogueLines.Length)
                {
                    CheckForName();
                    dialogueText.text = dialogueLines[currentLine];
                }else
                {
                    dialogueBox.SetActive(false);
                    MyPlayerController.instance.canMove = true; // Now player can move
                }
            }
        }
    }

    // Function to communicate with this script
    public void SetDialogue(string[] newLines, bool isPerson)
    {
        if(!dialogueBox.activeInHierarchy)
        {
            nameBox.SetActive(isPerson);
            dialogueLines = newLines;
            currentLine = 0;
            CheckForName();
            dialogueText.text = dialogueLines[currentLine];
            dialogueBox.SetActive(true);
            MyPlayerController.instance.canMove = false; // Player no longer can move 
        }
    }
    
    // Function to change name in dialogue box
    public void CheckForName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
